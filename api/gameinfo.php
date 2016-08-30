<?php
require_once('./commonfunc.php');



// ######################### REQUIRE BACK-END ############################
require_once "../../genfunc/sconfig.php";

// #######################################################################
// ######################## START MAIN SCRIPT ############################
// #######################################################################
$website=0;
$unregistered=0;
if (empty($_GET['appid'])) {
	echo "No appID provided!";
	exit;
} else {
	$appid=$_GET['appid'];
	
}


$userhrefbase="http://".$_SERVER['SERVER_NAME']."/member.php?u=";
//if ($showgi = capcu_fetch("dsc_gameinfo".$appid."-".$website."-".encrypt($logintocheck))) {
//	require_once('./css.php');
//	echo $showgi;
//} else {
	require_once('./css.php');
	$showgi="";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$servuuser=0;
	$websiteuser=0;
	$clientuser=0;
	//$passcheck = mysqli_query($link, "SELECT usergroupid, membergroupids, password FROM ds__vb_user WHERE username=\"".mysqli_real_escape_string($link, $logintocheck)."\"");
	//if (mysqli_num_rows($passcheck) or $unregistered == 1) {
	//	while ($row = mysqli_fetch_array($passcheck, MYSQLI_ASSOC)) {
	//		$md5pass=$row['password'];
	//		$usergroupid=$row['usergroupid'];
	//		$membership=$row['membergroupids'];
	//		if ($usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
	//			if ($usergroupid == 13) {
	//				$servuuser=1;
	//			}
	//			if ($usergroupid == 14) {
	//				$websiteuser=1;
	//			}
	//			if ($usergroupid == 15) {
	//				$clientuser=1;
	//			}
	//			if (strpos($membership, "13") !== false) {
	//				$servuuser=1;
	//			}
	//			if (strpos($membership, "14") !== false) {
	//				$websiteuser=1;
	//			}
	//			if (strpos($membership, "15") !== false) {
	//				$clientuser=1;
	//			}
	//		}
	//	}
		//if ($website == 1) {
			//$usergroupid=$vbulletin->userinfo['usergroupid'];
			//$membership=$vbulletin->userinfo['membergroupids'];
			//if ($usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
			//	if ($usergroupid == 13) {
			//		$servuuser=1;
			//	}
			//	if ($usergroupid == 14) {
			//		$websiteuser=1;
			//	}
			//	if ($usergroupid == 15) {
			//		$clientuser=1;
			//	}
			//	if (strpos($membership, "13") !== false) {
			//		$servuuser=1;
			//	}
			//	if (strpos($membership, "14") !== false) {
			//		$websiteuser=1;
			//	}
			//	if (strpos($membership, "15") !== false) {
			//		$clientuser=1;
			//	}
			//}
		//}
		//if ($passtocheck == Decrypt(Encrypt($md5pass)) or $website == 1) {
			$gamegrab = mysqli_query($link, "SELECT * FROM dsgamelist WHERE appID=\"".$appid."\"");
			if (mysqli_num_rows($gamegrab)) {





				while ($row = mysqli_fetch_array($gamegrab, MYSQLI_ASSOC)) {
					$showgi=$showgi. "<title>".$row['GameName']."</title>";
					$showgi=$showgi. "<script src=\"./jquery/jquery-2.0.3.min.js\"></script>";
					$showgi=$showgi. "<script type=\"text/javascript\">
						function toggle2(id, link) {
							var e = document.getElementById(id);
							if (e.style.display == \"\") {
								e.style.display = \"none\";
								$('html, body').animate({scrollTop:$('#'+id).position().top}, 'medium');
							} else {
								e.style.display = \"\";
								$('html, body').animate({scrollTop:$('#'+id).position().top}, 'medium');
							}
						}
						</script>";
					if ($row['headerimg'] != "") {
						$showgi=$showgi. "<center><img style=\"max-width:460;max-height:215;\" width=60% src=\"".$row['headerimg']."\" alt=\"".$row['GameName']."\" title=\"".$row['GameName']."\"><br><b>".$row['GameName']."</b></center><br>";
					} else {
						if (checkRemoteFile("http://cdn2.steampowered.com/v/gfx/apps/".$row['appID']."/header.jpg") === true) {
							$showgi=$showgi. "<center><img style=\"max-width:460;max-height:215;\" width=60% src=\"http://cdn2.steampowered.com/v/gfx/apps/".$row['appID']."/header.jpg\" alt=\"".$row['GameName']."\" title=\"".$row['GameName']."\"><br><b>".$row['GameName']."</b></center><br>";
						} else {
							$showgi=$showgi. "<center><b>".$row['GameName']."</b></center><br>";
						}
					}
					if ($row['gamefeatures'] != "") {
						$showgi=$showgi. "<center><table width=460px><tr><td align=center>";
						if (stripos($row['gamefeatures'], "captions") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_captions_available.png\" alt=\"Close captions available\" title=\"Close captions available\">";
						}
						if (stripos($row['gamefeatures'], "coop") !== false or stripos($row['gamefeatures'], "co-op") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_co_op.png\" alt=\"Internet or LAN co-op mode\" title=\"Internet or LAN co-op mode\">";
						}
						if (stripos($row['gamefeatures'], "commentary") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_commentary_available.png\" alt=\"Commentary available\" title=\"Commentary available\">";
						}
						if (stripos($row['gamefeatures'], "controller") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_full_controller_support.png\" alt=\"Gamepad support\" title=\"Gamepad support\">";
						}
						if (stripos($row['gamefeatures'], "hdr") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_hdr_available.png\" alt=\"HDR available\" title=\"HDR available\">";
						}
						if (stripos($row['gamefeatures'], "level editor") !== false or stripos($row['gamefeatures'], "sdk") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_includes_level_editor.png\" alt=\"Includes level editor or SDK\" title=\"Includes level editor or SDK\">";
						}
						if (stripos($row['gamefeatures'], "mods") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_mods.gif\" alt=\"Supports mods\" title=\"Supports mods\">";
						}
						if (stripos($row['gamefeatures'], "mmo") !== false or stripos($row['gamefeatures'], "multi-player") !== false or stripos($row['gamefeatures'], "multiplayer") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_multi_player.gif\" alt=\"Multiplayer\" title=\"Multiplayer\">";
						}
						if (stripos($row['gamefeatures'], "singleplayer") !== false or stripos($row['gamefeatures'], "single-player") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_single_player.png\" alt=\"Singleplayer\" title=\"Singleplayer\">";
						}
						if (stripos($row['gamefeatures'], "stats") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_stats.png\" alt=\"Statistics\" title=\"Statistics\">";
						}
						if (stripos($row['gamefeatures'], "achievements") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_steam_achievements.png\" alt=\"Achievements\" title=\"Achievements\">";
						}
						if (stripos($row['gamefeatures'], "cloud") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_steam_cloud.png\" alt=\"Steam cloud\" title=\"Steam cloud\">";
						}
						if (stripos($row['gamefeatures'], "leaderboards") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_steam_leaderboards.gif\" alt=\"Leaderboards\" title=\"Leaderboards\">";
						}
						if (stripos($row['gamefeatures'], "trading cards") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_steam_trading_cards.png\" alt=\"Steam trading cards\" title=\"Steam trading cards\">";
						}
						if (stripos($row['gamefeatures'], "workshop") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_steam_workshop.png\" alt=\"Steam workshop\" title=\"Steam workshop\">";
						}
						if (stripos($row['gamefeatures'], "anti-cheat") !== false) {
							$showgi=$showgi. "<img src=\"./feats/steamfeat_valve_anti_cheat_enabled.gif\" alt=\"Valve anti-cheat\" title=\"Valve anti-cheat\">";
						}
						$showgi=$showgi. "</td></tr></table></center>";
					}
					if ($clientuser == 1) {
						if ($row['exe1path'] != "" or $row['exe2path'] != "" or $row['exe3path'] != "" or $row['exe4path'] != "" or $row['exe5path'] != "" or $row['exe1desc'] != "" or $row['exe2desc'] != "" or $row['exe3desc'] != "" or $row['exe4desc'] != "" or $row['exe5desc'] != "") {
							$showgi=$showgi. "<span id=\"exeslinks\"><center><table width=460px><tr>";
							if ($row['exe1path'] != "") {
								$showgi=$showgi. "<td align=center><a href=\"dsc://run/".$row['appID']."\">".$row['exe1desc']."<sup title=\"Requires the game to be installed and appropriate .exe to be present\">[?]</sup></a></td>";
							}
							if ($row['exe2path'] != "") {
								$showgi=$showgi. "<td align=center><a href=\"dsc://run2/".$row['appID']."\">".$row['exe2desc']."<sup title=\"Requires the game to be installed and appropriate .exe to be present\">[?]</sup></a></td>";
							}
							if ($row['exe3path'] != "") {
								$showgi=$showgi. "<td align=center><a href=\"dsc://run3/".$row['appID']."\">".$row['exe3desc']."<sup title=\"Requires the game to be installed and appropriate .exe to be present\">[?]</sup></a></td>";
							}
							if ($row['exe4path'] != "") {
								$showgi=$showgi. "<td align=center><a href=\"dsc://run4/".$row['appID']."\">".$row['exe4desc']."<sup title=\"Requires the game to be installed and appropriate .exe to be present\">[?]</sup></a></td>";
							}
							if ($row['exe5path'] != "") {
								$showgi=$showgi. "<td align=center><a href=\"dsc://run5/".$row['appID']."\">".$row['exe5desc']."<sup title=\"Requires the game to be installed and appropriate .exe to be present\">[?]</sup></a></td>";
							}
							$showgi=$showgi. "</tr></table></center></span>";
						}
					}
					if ($row['gamedesc'] != "") {
						$showgi=$showgi. "<center><a target=_self href=\"#\" onclick=\"toggle2('description', this)\">Description</a><div id=\"description\" style=\"display:none\"><table><tr><td width=460px align=justify>".$row['gamedesc']."</td></tr></table></div></center><BR>";
					}
					$showgi=$showgi. "<center><table width=99% style=\"table-layout: fixed\"><tr><td align=center width=33%>General</td><td align=center width=33%>Technical</td><td align=center width=33%>Downloads</td></tr><tr>";
					$showgi=$showgi. "<td width=33% style=\"vertical-align: top\">";
					if ($row['releasedate'] != "" and $row['releasedate'] != 0) {
						$showgi=$showgi. "<center>Released on ".date("d.m.Y", $row['releasedate'])."</center><BR>";
					}
					if ($row['developers'] != "") {
						$showgi=$showgi. "<center>Developed by ".$row['developers']."</center><BR>";
					}
					if ($row['publishers'] != "") {
						$showgi=$showgi. "<center>Published by ".$row['publishers']."</center><BR>";
					}
					if ($row['reqage'] != "" and $row['reqage'] != "0") {
						$showgi=$showgi. "<center>Minimum age: ".$row['reqage']."</center><BR>";
					}
					if ($row['genres'] != "") {
						$showgi=$showgi. "<center>Genres: ".$row['genres']."</center><BR>";
					}
					if ($row['Language'] != "") {
						$showgi=$showgi. "<center>Language: <span title=\"This is default language. The game itself may include other languages. Also note, that some rare games report their language as English, but in fact use Russian (Max Payne, Max Payne 2, some Call of Duty titles)\">".$row['Language']."<a target=_self href=\"#\"><sup>[?]</sup></a></span></center><BR>";
					}
					if ($row['offwebsite'] != "") {
						$showgi=$showgi. "<center><a target=_blank href=\"".$row['offwebsite']."\">Official website</a></center><BR>";
					}
					$showgi=$showgi. "<center><a target=_blank title=\"May not work in case of some tools or in case of regional restrictions\" href=\"http://store.steampowered.com/app/".$row['appID']."\">Steam Store</a></center><BR>";
					$showgi=$showgi. "</td>";
					$showgi=$showgi. "<td width=33% style=\"vertical-align: top\">";
					$showgi=$showgi. "<center>AppID: ".$row['appID']."</center><br>";
					if ($row['Format'] != "") {
						$showgi=$showgi. "<center>Format: ".$row['Format']."</center><br>";
					}
					if ($row['LastUpdated'] != "" and $row['LastUpdated'] != "NULL") {
						$showgi=$showgi. "<center>Last update: ".$row['LastUpdated']."</center><br>";
					}
					if ($row['UpToDate'] == "0") {
						$showgi=$showgi. "<center>Up-to-date: <font color=red><b>No<a target=_self href=\"#\"><sup title=\"This application uses older Steam distribution system and format (NCF) or is not the latest version due to some other reasons. It still is playable if general guides are followed\">[?]</sup></a></b></font></center><br>";
					} else {
						$showgi=$showgi. "<center>Up-to-date: <font color=green><b>Yes<a target=_self href=\"#\"><sup title=\"This application is provided in its latest version as available on Steam. Please, note, that in some cases this can be also shown if game is provided in its second-to-last Steam version due to a delay in updates release between Steam and the service\">[?]</sup></a></b></font></center><br>";
					}
					if ($row['reqmin'] != "") {
						$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('reqmin', this)\"><center>Minimum requirements</center></a><div id=\"reqmin\" style=\"display:none\">".$row['reqmin']."</div>";
					}
					if ($row['reqrec'] != "") {
						$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('reqrec', this)\"><center>Recommended specifications</center></a><div id=\"reqrec\" style=\"display:none\">".$row['reqrec']."</div>";
					}
					if ($row['Format'] == "ACF") {
						$acfarray=explode("\\", $row['PathToACF']);
						$acf=end($acfarray);
						if ($website == 1) {
							$showgi=$showgi. "<center>ACF name: <a target=_self href=\"./mandown.php?file=".encrypt($acf)."\">".$acf."</a></center><br>";
						} else {
							$showgi=$showgi. "<center>ACF name: ".$acf."</center><br>";
						}
					}

					if ($row['realpath'] != "") {
						$dirarray=explode("/", $row['realpath']);
						$dir=end($dirarray);
						$showgi=$showgi. "<center>Common folder:<br>\"".$dir."\"</center><br>";
					}
					if ($row['ActiveDepots'] != "") {
						$deparray=explode(",", $row['ActiveDepots']);
						if ($row['Format'] == "ACF") {
							$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('depots', this)\"><center>List of manifests</center></a>";
						}
						if ($row['Format'] == "NCF") {
							$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('depots', this)\"><center>List of NCFs</center></a>";
						}
						$showgi=$showgi. "<div id=\"depots\" style=\"display:none\"><center>";
						natsort($deparray);
						foreach ($deparray as $dep) {
							if ($website == 1) {
								$showgi=$showgi. "<a target=\"_self\" href=\"./mandown.php?file=".encrypt($dep)."\">".$dep."</a><BR>";
							} else {
								$showgi=$showgi. $dep."<BR>";
							}
						}
						$showgi=$showgi. "</center></div>";
					}
					$showgi=$showgi. "</td>";
					$showgi=$showgi. "<td width=33% style=\"vertical-align: top\">";
					if ($row['GenAva'] == 0) {
						$showgi=$showgi. "<center><span title=\"The game is either being updated or was [temporary] removed.\"><font color=red>Temporary unavailable</font></span></center><br>";
					}
					if ($row['CommonFolderSize'] != "") {
						$showgi=$showgi. "<center><span title=\"Size taken from Steam. Actual size of the common folder may differ, especially, if there are some shared games (check appropriate section on this page if it exists)\">Size: ".FileSizeConvert($row['CommonFolderSize'])."<a target=_self href=\"#\"><sup>[?]</sup></a></span></center><br>";
					}
					$shgamegrab = mysqli_query($link, "SELECT appID, GameName FROM dsgamelist WHERE realpath=\"".mysqli_real_escape_string($link, $row['realpath'])."\" AND appID != \"".$appid."\" Order by GameName");
					if (mysqli_num_rows($shgamegrab)) {
						$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('shgames', this)\"><center>Shared games</center></a><div id=\"shgames\" style=\"display:none\">Downloading \"".$row['GameName']."\" you will also download the following applications, since they share the same common folder:<br><center>";
						while ($row2 = mysqli_fetch_array($shgamegrab, MYSQLI_ASSOC)) {
							$showgi=$showgi. "<a target=_self href=\"dsc://view/".$row2['appID']."\">".$row2['GameName']."</a><br>";
						}
						$showgi=$showgi. "</center></div>";
					}
					if ($row['GenAva'] == 1) {
						//if ($row['RegUser'] == 0 and $servuuser == 0 and $websiteuser == 0 and $clientuser == 0) {
							//$showgi=$showgi. "<center><a href=\"dsc://manifests/".$row['appID']."\">Download manifests</a></center><br>";
							//$showgi=$showgi. "<center><font color=red>Subscribe for download links</font><br><a target=_blank href=\"../payments.php\">Fast with PayPal</a></center>";
						//} elseif ($row['RegUser'] == 1 and $servuuser == 0 and $websiteuser == 0 and $clientuser == 0) {
							//$showgi=$showgi. "<center><a target=_self title=\"Use this link for manual download of known files. Not for batch download. Requires authorisation on main website\"href=\"./gamedir.php?appid=".$row['appID']."\">Download manually<sup>[?]</sup></a></center>";
						//} elseif ($servuuser == 1 or $websiteuser == 1 or $clientuser == 1) {
							$showgi=$showgi. "<center>";
							//if ($clientuser == 1) {
								$showgi=$showgi. "<a title=\"Will download both manifests and common folder with game files using the client\" href=\"dsc://install/".$row['appID']."\">Download full game<sup>[?]</sup></a><br>";
								$showgi=$showgi. "<a title=\"Will download only .acf, .ncf and\\or .manifest files using the client\" href=\"dsc://manifests/".$row['appID']."\">Download manifests<sup>[?]</sup></a>";
							//}
							//if ($row['RegUser'] == 1 AND $row['misstorr'] == 0 AND $row['tirrinpr'] == 0 AND is_file($row['torrname'])) {
								//$showgi=$showgi. "<br><a title=\"Will download .torrent file to download common folder. You can use it in torrent client of your liking\" href=\"./torrdown.php?appid=".$row['appID']."\">Download torrent<sup>[?]</sup></a>";
							//}
							//if ($servuuser == 1) {
							//	$showgi=$showgi. "<br><a target=_blank title=\"Use this link for manual download using Serv-U mirror. Requires prior authorisation in Serv-U in order to get directly into the folder\" href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['GameCommonFolder']."\">Download from Serv-U<sup>[?]</sup></a>";
							//}
							//if ($websiteuser == 1) {
								$showgi=$showgi. "<br><a target=_self title=\"Use this link for manual download of known files. Not for batch download. Requires authorisation on main website\"href=\"./gamedir.php?appid=".$row['appID']."\">Download manually<sup>[?]</sup></a>";
							//}
							$showgi=$showgi. "</center>";
							if ($row['crack1path'] != "" or $row['crack2path'] != "" or $row['crack3path'] != "" or $row['crack4path'] != "" or $row['crack5path'] != "" or $row['crack1desc'] != "" or $row['crack2desc'] != "" or $row['crack3desc'] != "" or $row['crack4desc'] != "" or $row['crack5desc'] != "") {
								$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('cracks', this)\"><center>Cracks info</center></a><div id=\"cracks\" style=\"display:none\">";
								if ($row['crack1desc'] != "") {
									$showgi=$showgi. $row['crack1desc']."<br>";
								}
								if ($row['crack1path'] != "") {
									if ($row['crack1path'] == "Not available") {
										$showgi=$showgi. "There is no crack available for this game at all. In order to play it you need to own it in Steam<br>";
									} elseif ($row['crack1path'] == "Not required") {
										$showgi=$showgi. "This game can be run by running appropriate .exe file without additional manipulation (unless stated otherwise), but use of GreenLuma (or similar cracked Steam client) is allowed as well<br>";
									} elseif ($row['crack1path'] == "GreenLuma") {
										$showgi=$showgi. "To run this game it's required either to have GreenLuma (or similar cracked Steam client) in background or start the game directly from it<br>";
									} elseif ($row['crack1path'] == "F2P") {
										$showgi=$showgi. "This is a free game and does not require purchase. Registration in Steam and\or other service may be required<br>";
									} elseif ($row['crack1path'] == "UPlay") {
										$showgi=$showgi. "This game requires cracked UPlay client in order to play it<br>";
									} else {
										//if ($clientuser == 1) {
											$showgi=$showgi. "<center><a href=\"dsc://crack/".$row['appID']."\">Download crack from client</a></center><br>";
										//}
										//if ($servuuser == 1) {
										//	$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['crack1path']."\">Download crack from Serv-U</a></center><br>";
										//}
									}
								}
								if ($row['crack2desc'] != "") {
									$showgi=$showgi. $row['crack2desc']."<br>";
								}
								if ($row['crack2path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://crack2/".$row['appID']."\">Download crack 2 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['crack2path']."\">Download crack 2 from Serv-U</a></center><br>";
									}
								}
								if ($row['crack3desc'] != "") {
									$showgi=$showgi. $row['crack3desc']."<br>";
								}
								if ($row['crack3path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://crack3/".$row['appID']."\">Download crack 3 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['crack3path']."\">Download crack 3 from Serv-U</a></center><br>";
									}
								}
								if ($row['crack4desc'] != "") {
									$showgi=$showgi. $row['crack4desc']."<br>";
								}
								if ($row['crack4path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://crack4/".$row['appID']."\">Download crack 4 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['crack4path']."\">Download crack 4 from Serv-U</a></center><br>";
									}
								}
								if ($row['crack5desc'] != "") {
									$showgi=$showgi. $row['crack5desc']."<br>";
								}
								if ($row['crack5path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://crack5/".$row['appID']."\">Download crack 5 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['crack5path']."\">Download crack 5 from Serv-U</a></center><br>";
									}
								}
								$showgi=$showgi. "</div>";
							} else {
								$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('cracks', this)\"><center>Cracks info</center></a><div id=\"cracks\" style=\"display:none\">This game was not tested for crack requirements and crack information is not available. You can try to run this game as is or using GreenLuma (or similar cracked Steam client), but it's not guaranteed to work, as game may require cracked .exe or .dll or other files and\or manipulations</div><br>";
							}
							if ($row['addon1path'] != "" or $row['addon2path'] != "" or $row['addon3path'] != "" or $row['addon4path'] != "" or $row['addon5path'] != "" or $row['addon1desc'] != "" or $row['addon2desc'] != "" or $row['addon3desc'] != "" or $row['addon4desc'] != "" or $row['addon5desc'] != "") {
								$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('addons', this)\"><center>Addons info</center></a><div id=\"addons\" style=\"display:none\">";
								if ($row['addon1desc'] != "") {
									$showgi=$showgi. $row['addon1desc']."<br>";
								}
								if ($row['addon1path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://addon/".$row['appID']."\">Download addon from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['addon1path']."\">Download addon from Serv-U</a></center><br>";
									}
								}
								if ($row['addon2desc'] != "") {
									$showgi=$showgi. $row['addon2desc']."<br>";
								}
								if ($row['addon2path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://addon2/".$row['appID']."\">Download addon 2 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['addon2path']."\">Download addon 2 from Serv-U</a></center><br>";
									}
								}
								if ($row['addon3desc'] != "") {
									$showgi=$showgi. $row['addon3desc']."<br>";
								}
								if ($row['addon3path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://addon3/".$row['appID']."\">Download addon 3 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['addon3path']."\">Download addon 3 from Serv-U</a></center><br>";
									}
								}
								if ($row['addon4desc'] != "") {
									$showgi=$showgi. $row['addon4desc']."<br>";
								}
								if ($row['addon4path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://addon4/".$row['appID']."\">Download addon 4 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['addon4path']."\">Download addon 4 from Serv-U</a></center><br>";
									}
								}
								if ($row['addon5desc'] != "") {
									$showgi=$showgi. $row['addon5desc']."<br>";
								}
								if ($row['addon5path'] != "") {
									if ($clientuser == 1) {
										$showgi=$showgi. "<center><a href=\"dsc://addon5/".$row['appID']."\">Download addon 5 from client</a></center><br>";
									}
									if ($servuuser == 1) {
										$showgi=$showgi. "<center><a target=_blank href=\"http://".$_SERVER['SERVER_NAME'].":81/?dir=".$row['addon5path']."\">Download addon 5 from Serv-U</a></center><br>";
									}
								}
								$showgi=$showgi. "</div>";
							}
						//} else {
						//	$showgi=$showgi. "<center><font color=red>Insufficient priviliges to view download links</font></center>";
						//}
					} else {
						$showgi=$showgi. "<center><font color=red>Game files temporary unavailable</font></center>";
					}
					$showgi=$showgi. "</td>";
					$showgi=$showgi. "</tr>";
					if ($row['alldlcids'] != "") {
						$showgi=$showgi. "<tr><td colspan=3 style=\"vertical-align: top;table-layout: auto\"><a target=_self href=\"#\" onclick=\"toggle2('dlcinfo', this)\"><center>DLC information</center></a></td></tr><div>";
						$showgi=$showgi. "<table width=99% id=\"dlcinfo\" style=\"table-layout: fixed;display:none\">";
						if ($row['alldlcheads'] != "") {
							$showgi=$showgi. "<tr><td colspan=3 style=\"vertical-align: top;table-layout: auto\"><center>";
							$dheadsarray=explode(";", $row['alldlcheads']);
							foreach ($dheadsarray as $dep) {
								$showgi=$showgi. "<img width=230px src=\"".$dep."\">";
							}
							$showgi=$showgi. "</center></td></tr>";
						}
						$showgi=$showgi. "<tr>";
						if ($row['alldlcnames'] != "") {
							$showgi=$showgi. "<td style=\"vertical-align: top\">";
							$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('dlcnames', this)\"><center>DLC names</center></a><div id=\"dlcnames\" style=\"display:none\"><center>";
							$dnamesarray=explode(";", $row['alldlcnames']);
							foreach ($dnamesarray as $dep) {
								$showgi=$showgi. $dep."<BR>";
							}
							$showgi=$showgi. "</center></div></td>";
						}
						if ($row['alldlcdesc'] != "") {
							$showgi=$showgi. "<td style=\"vertical-align: top\">";
							$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('dlcdesc', this)\"><center>DLC descriptions</center></a><div id=\"dlcdesc\" style=\"display:none\">";
							$ddescarray=explode(";!!!;", $row['alldlcdesc']);
							foreach ($ddescarray as $dep) {
								$showgi=$showgi. $dep."<hr>";
							}
							$showgi=$showgi. "</div></td>";
						}
						if ($row['alldlcids'] != "") {
							$showgi=$showgi. "<td style=\"vertical-align: top\">";
							$showgi=$showgi. "<a target=_self href=\"#\" onclick=\"toggle2('dlcids', this)\"><center>DLC IDs</center></a><div id=\"dlcids\" style=\"display:none\"><center>";
							$didsarray=explode(";", $row['alldlcids']);
							foreach ($didsarray as $dep) {
								$showgi=$showgi. $dep."<BR>";
							}
							$showgi=$showgi. "</center></div></td>";
						}
						$showgi=$showgi. "</tr>";
						$showgi=$showgi. "</table></div>";
					}
					if ($row['screenshots'] != "") {
						$showgi=$showgi. "<tr><td colspan=3 style=\"vertical-align: top;table-layout: auto\"><a target=_self href=\"#\" onclick=\"toggle2('screens', this)\"><center>Screenshots</center></a><div id=\"screens\" style=\"display:none\"><center><br>";
						$scrarray=explode(";", $row['screenshots']);
						foreach ($scrarray as $dep) {
							if (stripos($dep, "600x338") !== false) {
								$showgi=$showgi. "<a target=_blank href=\"".str_replace("600x338", "1920x1080", $dep)."\"><img style=\"max-width:600;\" width=90% title=\"Click me for higher resolution\" src=\"".$dep."\"></a><br><br>";
							}
						}
						$showgi=$showgi. "</center></div></td></tr>";
					}
					$showgi=$showgi. "</table></center>
					<a target=_self href=\"#\" class=\"back-to-top\">Back to Top</a>
					<script>jQuery(document).ready(function() {
						var offset = $(window).height()/100;
						var duration = 500;
 						jQuery(window).scroll(function() {
							if (jQuery(this).scrollTop() > offset) {
								jQuery('.back-to-top').fadeIn(duration);
							} else {
								jQuery('.back-to-top').fadeOut(duration);
							}
						});
    
						jQuery('.back-to-top').click(function(event) {
							event.preventDefault();
							jQuery('html, body').animate({scrollTop: 0}, duration);
							return false;
						})
					});</script>
					";
					//if ($website == 1) {
						$showgi=$showgi. "<script>
							var links = document.getElementsByTagName(\"a\");
							for(var i = 0; i < links.length; i++) {
								if (links[i].href.substring(0, 11) == \"dsc://view/\") {
									links[i].href = links[i].href.replace(\"dsc://view/\", \"./gameinfo.php?appid=\");
								}
							}
						</script>";
					//}
				}
			echo $showgi;
			//capcu_store("dsc_gameinfo".$appid."-".$website."-".encrypt($logintocheck), $showgi, 900);
			} else {
				$showgi=$showgi. "Wrong appID!";
				mysqli_close($link);
				echo $showgi; 
				exit;
			}
			mysqli_close($link);
			exit;
		//} else {
		//	$strupd = mysqli_query($link, "INSERT INTO ds__vb_strikes (striketime, strikeip, username) VALUES (".time().", \"".$_SERVER['REMOTE_ADDR']."\", \"".mysqli_real_escape_string($link, $logintocheck)."\")");
		//	$showgi=$showgi. "Wrong password!";
		//	mysqli_close($link);
		//	echo $showgi; 
		//	exit;
		//}
	//}
	mysqli_close($link);
//}
}
?>