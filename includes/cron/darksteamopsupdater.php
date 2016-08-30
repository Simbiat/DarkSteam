<?php
if ($handle = opendir($acfregpath)) {
	while (false !== ($file = readdir($handle)))
		{
			if ($file != "." && $file != ".." && strtolower(substr($file, strrpos($file, '.') + 1)) == 'acf')
				{
					Echo "Updating info for file <b>".$file."</b>... ";
					$modtime = date("d.m.Y H:i", filemtime($acfregpath.$file));
					$ActiveDepotsliststart = 0;
					$manemptyline = 0;
					$ActiveDepotslist="";
					$realpath="";
					$gamedesc="";
					$gamefeatures="";
					$gamestate=4;
					$acffile = file($acfregpath.$file);
					$LastUpdated = "NULL";
					foreach ($acffile as $acfline) {
						$explline = explode('"', $acfline);
						if (strcasecmp($explline[1], "appid") == 0) {
							$appid = $explline[3];
						}
						if (strcasecmp($explline[1], "StateFlags") == 0) {
							$gamestate = $explline[3];
						}
						if (strcasecmp($explline[1], "SizeOnDisk") == 0) {
							$sizeondisk = $explline[3];
						}
						if (strcasecmp($explline[1], "name") == 0) {
							$gamename = $explline[3];
							$gamename = preg_replace("/[^A-Za-z0-9-.?!,:()'& ]+/", "", $gamename);
							$gamename = preg_replace("/\&/","and", $gamename);
						}
						if (strcasecmp($explline[1], "installdir") == 0) {
							$realpath = $acfregpath."common/".$explline[3];
						}
						if (strcasecmp($explline[1], "LastUpdated") == 0) {
							$LastUpdated = $explline[3];
						}
						if (strcasecmp($explline[1], "language") == 0) {
							$gamelang = $explline[3];
						}
						if (strcasecmp($explline[1], "MountedDepots") == 0) {
							$ActiveDepotsliststart = 1;
						}
						if (strcasecmp($explline[1], "SharedDepots") == 0) {
							$ActiveDepotsliststart = 0;
						}
						if (strcasecmp($explline[1], "CheckGuid") == 0) {
							$ActiveDepotsliststart = 0;
						}
						if (strcasecmp($explline[1], "InstallScripts") == 0) {
							$ActiveDepotsliststart = 0;
						}
						if ($ActiveDepotsliststart == 1) {
							if (strcasecmp($explline[1], "MountedDepots") !== 0 && (string)(int)$explline[1] == $explline[1]) {
								$ActiveDepotslist = $ActiveDepotslist.",".$explline[1]."_".$explline[3].".manifest";
							}
						}
					}
					if ($gamestate != 4) {
						$link = mysqli_connect("$host", "$username", "$password", "$db_name");
						if (!$link) {
							die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
						} else {
							$acfrowcheck = mysqli_query($link, "SELECT appID FROM dsgamelist WHERE appID=".$appid);
							if (mysqli_num_rows($acfrowcheck)) {
								$acfupdate = mysqli_query($link, "UPDATE dsgamelist SET dsgamelist.GenAva=0, dsgamelist.misstorr=1 WHERE appID=".$appid);
							}
							mysqli_close($link);
						}
						continue;
					} else {
						if (file_exists($acfregpath."downloading/".$appid)) {
							$link = mysqli_connect("$host", "$username", "$password", "$db_name");
							if (!$link) {
								die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
							} else {
								$acfrowcheck = mysqli_query($link, "SELECT appID FROM dsgamelist WHERE appID=".$appid);
								if (mysqli_num_rows($acfrowcheck)) {
									$acfupdate = mysqli_query($link, "UPDATE dsgamelist SET dsgamelist.GenAva=1, dsgamelist.misstorr=1 WHERE appID=".$appid);
								}
								mysqli_close($link);
							}
							continue;
						}
					}
					$ActiveDepotslist = substr($ActiveDepotslist, 1);
					//log_cron_action("DS Ops: ".$gamename, $nextitem);
					$link = mysqli_connect("$host", "$username", "$password", "$db_name");
					if (!$link) {
						die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
					} else {
						$acfrowcheck = mysqli_query($link, "SELECT ".$appid." FROM dsgamelist WHERE appid=".$appid);
						if (mysqli_num_rows($acfrowcheck)) {
							$acfrowcheck2 = mysqli_query($link, "SELECT ".$appid." FROM dsgamelist WHERE appid=".$appid." AND Format=\"ACF\" AND PathToACF=\"".$file."\" AND LastUpdated=\"".$modtime."\" AND UpdatedOn=".$LastUpdated." AND UpToDate=1 AND GameName=\"".$gamename."\" AND CommonFolderSize=\"".$sizeondisk."\" AND Language=\"".$gamelang."\" AND ActiveDepots=\"".$ActiveDepotslist."\" AND RegUser=".$regusavail." AND GenAva=1 and realpath=\"".$realpath."\"");
							if (!mysqli_num_rows($acfrowcheck2)) {
								$reqage="";
								$headerimg="";
								$offwebsite="";
								$reqmin="";
								$reqrec="";
								$developers="";
								$publishers="";
								$genres="";
								$screens="";
								$reldate="0";
								$gamedesc="";
								$gamefeats="";
								$alldlcnames="";
								$allappids="";
								$alldlcdesc="";
								$alldlcheads="";
								$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$appid);
								$fullappinfo=json_decode($jsonstring, true);
								if ($fullappinfo[$appid]['success']) {
									$reqage=$fullappinfo[$appid]['data']['required_age'];
									$headerimg=$fullappinfo[$appid]['data']['header_image'];
									$offwebsite=$fullappinfo[$appid]['data']['website'];
									$reqmin=$fullappinfo[$appid]['data']['pc_requirements']['minimum'];
									$reqrec=$fullappinfo[$appid]['data']['pc_requirements']['recommended'];
									$developers=multi_implode($fullappinfo[$appid]['data']['developers'], ";");
									$publishers=multi_implode($fullappinfo[$appid]['data']['publishers'], ";");
									$genres=multi_implode($fullappinfo[$appid]['data']['genres'], ";");
									$screens=multi_implode($fullappinfo[$appid]['data']['screenshots'], ";");
									$reldate=strtotime($fullappinfo[$appid]['data']['release_date']['date']);
									if (!is_numeric($reldate)) {
										$reldate=0;
									}
									$gamedesc=$fullappinfo[$appid]['data']['detailed_description'];
									$gamefeats=multi_implode($fullappinfo[$appid]['data']['categories'], ";");
								}
								if ($ActiveDepotslist != "") {
									$explodedmanifests = explode(",", $ActiveDepotslist, 999999999);
									foreach ($explodedmanifests as $explodeddeps) {
										$explodedmanifests2 = explode("_", $explodeddeps, 100);
										if ($explodedmanifests2[0] != $appid) {
											$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$explodedmanifests2[0]);
											$fullappinfo=json_decode($jsonstring, true);
											if ($fullappinfo[$explodedmanifests2[0]]['success']) {
												$title = preg_replace("/[^A-Za-z0-9-.?!,:()'#& ]+/", "", $fullappinfo[$explodedmanifests2[0]]['data']['name']);
												$title = str_replace(";", " ", $title);
												if (trim($title) !="" and stripos($title, $gamename." content") === false and stripos($title, "DirectX") === false and stripos($title, "PhysX") === false and stripos($title, "OpenAL") === false and stripos($title, "VC 2008 Redist") === false and stripos($title, "VC 2009 Redist") === false and stripos($title, "VC 2010 Redist") === false and stripos($title, "VC 2011 Redist") === false and stripos($title, "VC 2012 Redist") === false and stripos($title, "VC 2013 Redist") === false and stripos($title, "VC 2014 Redist") === false and stripos($title, "VC 2015 Redist") === false and stripos($title, "VC 2016 Redist") === false and stripos($title, "VC 2017 Redist") === false and stripos($title, ".NET 4.0 Redist") === false and stripos($title, ".NET 4.5 Redist") === false and stripos($title, ".NET 3.0 Redist") === false and stripos($title, ".NET 3.5 Redist") === false and stripos($title, $gamename."content") === false and stripos($title, $gamename." depot") === false and stripos($title, $gamename."depot") === false and stripos($title, $gamename." full") === false and stripos($title, $gamename."full") === false and stripos($title, $gamename." complete") === false and stripos($title, $gamename."complete") === false and stripos($title, "Unknown App") === false and stripos($title, "Win32 Build") === false and stripos($title, $gamename."-file") === false and stripos($title, $gamename." win") === false and stripos($title, $gamename."win") === false and stripos($title, $gamename." common") === false and stripos($title, $gamename."common") === false and stripos($title, $gamename." english") === false and stripos($title, $gamename."English") === false and stripos($title, $gamename."shared") === false and stripos($title, $gamename." shared") === false and stripos($title, $gamename." main") === false and stripos($title, $gamename."main") === false) {
													if (trim($title) !="" AND trim($fullappinfo[$explodedmanifests2[0]]['data']['name']) !="" AND stripos($allappids, $explodedmanifests2[0]) === false) {
														$alldlcnames=$alldlcnames.trim($title).";";
														$alldlcdesc=$alldlcdesc.trim($fullappinfo[$explodedmanifests2[0]]['data']['detailed_description']).";!!!;";
														$alldlcheads=$alldlcheads.trim($fullappinfo[$explodedmanifests2[0]]['data']['header_image']).";";
														$allappids=$allappids.$explodedmanifests2[0].";";
													}
												}
											} else {
												if (substr($explodedmanifests2[0], 0, -1)."0" != $appid) {
													$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".substr($explodedmanifests2[0], 0, -1)."0");
													$fullappinfo=json_decode($jsonstring, true);
													if ($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['success']) {
														$title = preg_replace("/[^A-Za-z0-9-.?!,:()'#& ]+/", "", $fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['name']);
														$title = str_replace(";", " ", $title);
														if (trim($title) !="" and stripos($title, $gamename." content") === false and stripos($title, "DirectX") === false and stripos($title, "PhysX") === false and stripos($title, "OpenAL") === false and stripos($title, "VC 2008 Redist") === false and stripos($title, "VC 2009 Redist") === false and stripos($title, "VC 2010 Redist") === false and stripos($title, "VC 2011 Redist") === false and stripos($title, "VC 2012 Redist") === false and stripos($title, "VC 2013 Redist") === false and stripos($title, "VC 2014 Redist") === false and stripos($title, "VC 2015 Redist") === false and stripos($title, "VC 2016 Redist") === false and stripos($title, "VC 2017 Redist") === false and stripos($title, ".NET 4.0 Redist") === false and stripos($title, ".NET 4.5 Redist") === false and stripos($title, ".NET 3.0 Redist") === false and stripos($title, ".NET 3.5 Redist") === false and stripos($title, $gamename."content") === false and stripos($title, $gamename." depot") === false and stripos($title, $gamename."depot") === false and stripos($title, $gamename." full") === false and stripos($title, $gamename."full") === false and stripos($title, $gamename." complete") === false and stripos($title, $gamename."complete") === false and stripos($title, "Unknown App") === false and stripos($title, "Win32 Build") === false and stripos($title, $gamename."-file") === false and stripos($title, $gamename." win") === false and stripos($title, $gamename."win") === false and stripos($title, $gamename." common") === false and stripos($title, $gamename."common") === false and stripos($title, $gamename." english") === false and stripos($title, $gamename."English") === false and stripos($title, $gamename."shared") === false and stripos($title, $gamename." shared") === false and stripos($title, $gamename." main") === false and stripos($title, $gamename."main") === false) {
															if (trim($title) !="" AND trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['name']) !="" AND stripos($allappids, substr($explodedmanifests2[0], 0, -1)."0") === false) {
																$alldlcnames=$alldlcnames.trim($title).";";
																$alldlcdesc=$alldlcdesc.trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['detailed_description']).";!!!;";
																$alldlcheads=$alldlcheads.trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['header_image']).";";
																$allappids=$allappids.substr($explodedmanifests2[0], 0, -1)."0".";";
															}
														}
													}
												}
											}
										}
									}
								}
								$acfupdate = mysqli_query($link, "UPDATE dsgamelist SET dsgamelist.reqage=\"".$reqage."\", dsgamelist.headerimg=\"".mysqli_real_escape_string($link, $headerimg)."\", dsgamelist.offwebsite=\"".mysqli_real_escape_string($link, $offwebsite)."\", dsgamelist.reqmin=\"".mysqli_real_escape_string($link, $reqmin)."\", dsgamelist.reqrec=\"".mysqli_real_escape_string($link, $reqrec)."\", dsgamelist.developers=\"".mysqli_real_escape_string($link, $developers)."\", dsgamelist.publishers=\"".mysqli_real_escape_string($link, $publishers)."\", dsgamelist.genres=\"".mysqli_real_escape_string($link, $genres)."\", dsgamelist.screenshots=\"".mysqli_real_escape_string($link, $screens)."\", dsgamelist.releasedate=\"".$reldate."\", dsgamelist.gamedesc=\"".mysqli_real_escape_string($link, $gamedesc)."\", dsgamelist.gamefeatures=\"".mysqli_real_escape_string($link, $gamefeats)."\", dsgamelist.alldlcids=\"".mysqli_real_escape_string($link, substr($allappids, 0, -1))."\", dsgamelist.alldlcdesc=\"".mysqli_real_escape_string($link, substr($alldlcdesc, 0, -5))."\", dsgamelist.alldlcheads=\"".mysqli_real_escape_string($link, substr($alldlcheads, 0, -1))."\", dsgamelist.alldlcnames=\"".mysqli_real_escape_string($link, substr($alldlcnames, 0, -1))."\", dsgamelist.Format=\"ACF\", dsgamelist.PathToACF=\"".$file."\", dsgamelist.LastUpdated=\"".$modtime."\", dsgamelist.UpdatedOn=".$LastUpdated.", dsgamelist.UpToDate=1, dsgamelist.GameName=\"".$gamename."\", dsgamelist.CommonFolderSize=\"".$sizeondisk."\", dsgamelist.Language=\"".$gamelang."\", dsgamelist.ActiveDepots=\"".$ActiveDepotslist."\", dsgamelist.RegUser=".$regusavail.", dsgamelist.GenAva=1, misstorr=1, realpath=\"".$realpath."\" WHERE appid=".$appid);
								echo "Affected rows: <b>". mysqli_affected_rows($link)."</b><br>";
								if (extension_loaded('apcu') === true) {
									$toDelete = new APCIterator("user", "/^dsc_gameinfo".$appid."/", apcu_ITER_VALUE);
									apcu_delete($toDelete);
								}
								$apctoclear=1;
							}
						} else {
							$acfaddedon = time();
							$reqage="";
							$headerimg="";
							$offwebsite="";
							$reqmin="";
							$reqrec="";
							$developers="";
							$publishers="";
							$genres="";
							$screens="";
							$reldate="0";
							$gamedesc="";
							$gamefeats="";
							$alldlcnames="";
							$allappids="";
							$alldlcdesc="";
							$alldlcheads="";
							$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$appid);
							$fullappinfo=json_decode($jsonstring, true);
							if ($fullappinfo[$appid]['success']) {
								$reqage=$fullappinfo[$appid]['data']['required_age'];
								$headerimg=$fullappinfo[$appid]['data']['header_image'];
								$offwebsite=$fullappinfo[$appid]['data']['website'];
								$reqmin=$fullappinfo[$appid]['data']['pc_requirements']['minimum'];
								$reqrec=$fullappinfo[$appid]['data']['pc_requirements']['recommended'];
								$developers=multi_implode($fullappinfo[$appid]['data']['developers'], ";");
								$publishers=multi_implode($fullappinfo[$appid]['data']['publishers'], ";");
								$genres=multi_implode($fullappinfo[$appid]['data']['genres'], ";");
								$screens=multi_implode($fullappinfo[$appid]['data']['screenshots'], ";");
								$reldate=strtotime($fullappinfo[$appid]['data']['release_date']['date']);
								if (!is_numeric($reldate)) {
									$reldate=0;
								}
								$gamedesc=$fullappinfo[$appid]['data']['detailed_description'];
								$gamefeats=multi_implode($fullappinfo[$appid]['data']['categories'], ";");
							}
							if ($ActiveDepotslist != "") {
								$explodedmanifests = explode(",", $ActiveDepotslist, 999999999);
								foreach ($explodedmanifests as $explodeddeps) {
									$explodedmanifests2 = explode("_", $explodeddeps, 100);
									if ($explodedmanifests2[0] != $appid) {
										$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$explodedmanifests2[0]);
										$fullappinfo=json_decode($jsonstring, true);
										if ($fullappinfo[$explodedmanifests2[0]]['success']) {
											$title = preg_replace("/[^A-Za-z0-9-.?!,:()'#& ]+/", "", $fullappinfo[$explodedmanifests2[0]]['data']['name']);
											$title = str_replace(";", " ", $title);
											if (trim($title) !="" and stripos($title, $gamename." content") === false and stripos($title, "DirectX") === false and stripos($title, "PhysX") === false and stripos($title, "OpenAL") === false and stripos($title, "VC 2008 Redist") === false and stripos($title, "VC 2009 Redist") === false and stripos($title, "VC 2010 Redist") === false and stripos($title, "VC 2011 Redist") === false and stripos($title, "VC 2012 Redist") === false and stripos($title, "VC 2013 Redist") === false and stripos($title, "VC 2014 Redist") === false and stripos($title, "VC 2015 Redist") === false and stripos($title, "VC 2016 Redist") === false and stripos($title, "VC 2017 Redist") === false and stripos($title, ".NET 4.0 Redist") === false and stripos($title, ".NET 4.5 Redist") === false and stripos($title, ".NET 3.0 Redist") === false and stripos($title, ".NET 3.5 Redist") === false and stripos($title, $gamename."content") === false and stripos($title, $gamename." depot") === false and stripos($title, $gamename."depot") === false and stripos($title, $gamename." full") === false and stripos($title, $gamename."full") === false and stripos($title, $gamename." complete") === false and stripos($title, $gamename."complete") === false and stripos($title, "Unknown App") === false and stripos($title, "Win32 Build") === false and stripos($title, $gamename."-file") === false and stripos($title, $gamename." win") === false and stripos($title, $gamename."win") === false and stripos($title, $gamename." common") === false and stripos($title, $gamename."common") === false and stripos($title, $gamename." english") === false and stripos($title, $gamename."English") === false and stripos($title, $gamename."shared") === false and stripos($title, $gamename." shared") === false and stripos($title, $gamename." main") === false and stripos($title, $gamename."main") === false) {
												if (trim($title) !="" AND trim($fullappinfo[$explodedmanifests2[0]]['data']['name']) !="" AND stripos($allappids, $explodedmanifests2[0]) === false) {
													$alldlcnames=$alldlcnames.trim($title).";";
													$alldlcdesc=$alldlcdesc.trim($fullappinfo[$explodedmanifests2[0]]['data']['detailed_description']).";!!!;";
													$alldlcheads=$alldlcheads.trim($fullappinfo[$explodedmanifests2[0]]['data']['header_image']).";";
													$allappids=$allappids.$explodedmanifests2[0].";";
												}
											}
										} else {
											if (substr($explodedmanifests2[0], 0, -1)."0" != $appid) {
												$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".substr($explodedmanifests2[0], 0, -1)."0");
												$fullappinfo=json_decode($jsonstring, true);
												if ($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['success']) {
													$title = preg_replace("/[^A-Za-z0-9-.?!,:()'#& ]+/", "", $fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['name']);
													$title = str_replace(";", " ", $title);
													if (trim($title) !="" and stripos($title, $gamename." content") === false and stripos($title, "DirectX") === false and stripos($title, "PhysX") === false and stripos($title, "OpenAL") === false and stripos($title, "VC 2008 Redist") === false and stripos($title, "VC 2009 Redist") === false and stripos($title, "VC 2010 Redist") === false and stripos($title, "VC 2011 Redist") === false and stripos($title, "VC 2012 Redist") === false and stripos($title, "VC 2013 Redist") === false and stripos($title, "VC 2014 Redist") === false and stripos($title, "VC 2015 Redist") === false and stripos($title, "VC 2016 Redist") === false and stripos($title, "VC 2017 Redist") === false and stripos($title, ".NET 4.0 Redist") === false and stripos($title, ".NET 4.5 Redist") === false and stripos($title, ".NET 3.0 Redist") === false and stripos($title, ".NET 3.5 Redist") === false and stripos($title, $gamename."content") === false and stripos($title, $gamename." depot") === false and stripos($title, $gamename."depot") === false and stripos($title, $gamename." full") === false and stripos($title, $gamename."full") === false and stripos($title, $gamename." complete") === false and stripos($title, $gamename."complete") === false and stripos($title, "Unknown App") === false and stripos($title, "Win32 Build") === false and stripos($title, $gamename."-file") === false and stripos($title, $gamename." win") === false and stripos($title, $gamename."win") === false and stripos($title, $gamename." common") === false and stripos($title, $gamename."common") === false and stripos($title, $gamename." english") === false and stripos($title, $gamename."English") === false and stripos($title, $gamename."shared") === false and stripos($title, $gamename." shared") === false and stripos($title, $gamename." main") === false and stripos($title, $gamename."main") === false) {
														if (trim($title) !="" AND trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['name']) !="" AND stripos($allappids, substr($explodedmanifests2[0], 0, -1)."0") === false) {
															$alldlcnames=$alldlcnames.trim($title).";";
															$alldlcdesc=$alldlcdesc.trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['detailed_description']).";!!!;";
															$alldlcheads=$alldlcheads.trim($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['data']['header_image']).";";
															$allappids=$allappids.substr($explodedmanifests2[0], 0, -1)."0".";";
														}
													}
												}
											}
										}
									}
								}
							}
							$acfupdate = mysqli_query($link, "INSERT INTO dsgamelist (appID, Format, PathToACF, LastUpdated, UpdatedOn, AddedOn, UpToDate, GameName, CommonFolderSize, Language, ActiveDepots, RegUser, GenAva, exe1path, exe1desc, crack1path, crack1desc, addon1path, addon1desc, exe2path, exe2desc, crack2path, crack2desc, addon2path, addon2desc, exe3path, exe3desc, crack3path, crack3desc, addon3path, addon3desc, exe4path, exe4desc, crack4path, crack4desc, addon4path, addon4desc, exe5path, exe5desc, crack5path, crack5desc, addon5path, addon5desc, misstorr, torrname, reqage, headerimg, offwebsite, reqmin, reqrec, developers, publishers, genres, screenshots, releasedate, gamedesc, gamefeatures, alldlcids, alldlcdesc, alldlcheads, alldlcnames, realpath) VALUES (\"".$appid."\", \"ACF\", \"".$file."\", \"".$modtime."\", \"".$LastUpdated."\", \"".$acfaddedon."\", 1, \"".$gamename."\", \"".$sizeondisk."\", \"".$gamelang."\", \"".$ActiveDepotslist."\", \"".$regusavail."\", 1, \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", \"\", 1, \"\", \"".$reqage."\", \"".mysqli_real_escape_string($link, $headerimg)."\", \"".mysqli_real_escape_string($link, $offwebsite)."\", \"".mysqli_real_escape_string($link, $reqmin)."\", \"".mysqli_real_escape_string($link, $reqrec)."\", \"".mysqli_real_escape_string($link, $developers)."\", \"".mysqli_real_escape_string($link, $publishers)."\", \"".mysqli_real_escape_string($link, $genres)."\", \"".mysqli_real_escape_string($link, $screens)."\", \"".$reldate."\", \"".mysqli_real_escape_string($link, $gamedesc)."\", \"".mysqli_real_escape_string($link, $gamefeats)."\", \"".mysqli_real_escape_string($link, substr($allappids, 0, -1))."\", \"".mysqli_real_escape_string($link, substr($alldlcdesc, 0, -5))."\", \"".mysqli_real_escape_string($link, substr($alldlcheads, 0, -1))."\", \"".mysqli_real_escape_string($link, substr($alldlcnames, 0, -1))."\", \"".$realpath."\")");
						}
					echo "Affected rows: <b>". mysqli_affected_rows($link)."</b><br>";
					if (extension_loaded('apcu') === true) {
						$toDelete = new APCIterator("user", "/^dsc_gameinfo".$appid."/", apcu_ITER_VALUE);
						apcu_delete($toDelete);
					}
					$apctoclear=1;
					mysqli_close($link);
					}
				}
		}
	closedir($handle);
}

?>
