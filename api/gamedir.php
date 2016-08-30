<?php
require_once('./commonfunc.php');


ini_set( "display_errors", 0);

// ######################### REQUIRE BACK-END ############################
require_once "../config.php";

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


$correctimgsrc="<img src=\"http://".$_SERVER['SERVER_NAME']."/";
$userhrefbase="http://".$_SERVER['SERVER_NAME']."/member.php?u=";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
/*
	$passcheck = mysqli_query($link, "SELECT usergroupid, membergroupids, password FROM ds__vb_user WHERE username=\"".mysqli_real_escape_string($link, $logintocheck)."\"");
	if (mysqli_num_rows($passcheck) or $unregistered == 1) {
		while ($row = mysqli_fetch_array($passcheck, MYSQLI_ASSOC)) {
			$md5pass=$row['password'];
			$usergroupid=$row['usergroupid'];
			$membership=$row['membergroupids'];
			if ($usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
				if ($usergroupid == 14) {
					$usergroupid=14;
				} else {
					if (strpos($membership, "14") === false) {
						$usergroupid=2;
					} else {
						$usergroupid=14;
					}
				}
			}
		}
		if ($website == 1) {
			$usergroupid=$vbulletin->userinfo['usergroupid'];
			$membership=$vbulletin->userinfo['membergroupids'];
			if ($usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
				if ($usergroupid == 14) {
					$usergroupid=14;
				} else {
					if (strpos($membership, "14") === false) {
						$usergroupid=2;
					} else {
						$usergroupid=13;
					}
				}
			}
		}
*/
		//if ($passtocheck == Decrypt(Encrypt($md5pass)) or $website == 1) {
			$gamegrab = mysqli_query($link, "SELECT appID, GameName, realpath, RegUser, GenAva FROM dsgamelist WHERE appID=\"".$appid."\"");
			if (mysqli_num_rows($gamegrab)) {
				while ($row = mysqli_fetch_array($gamegrab, MYSQLI_ASSOC)) {
					echo "<title>".$row['GameName']."</title>";
					require_once('./css.php');
					if ($row['GenAva'] == 1) {
						//if ($row['RegUser'] == 0 and $usergroupid != 13) {
						//	echo "<center><font color=red>Subscribe for full download</font><br><a href=\"../payments.php\">Fast with PayPal</a><br><a href=\"../threads/333741-PayPal-Alternatives\">Alternative subscriptions</a></center>";
						//} else {
							//if ($usergroupid == 2 or $usergroupid == 13) {
								if ($row['realpath'] != "") {
									$dirarray=explode("/", $row['realpath']);
									$dircom=end($dirarray);
									$startdir = '';
									foreach ($allowsdirsl as $path) {
										if (file_exists($path.$dircom)) {
											$startdir=$path.$dircom;
										}
									}
									if ($startdir != '') {
										require_once('./dirlist.php');
									} else {
										echo "<a class=\"intlink\" href=./gameinfo.php?appid=".$appid.">Back</a><br>";
										echo "Directory not present!";
									}
								} else {
									Echo "No common folder specified";
								}
							//} else {
							//	echo "<center>You do not have sufficient priviliges to see download links</center>";
							//}
						//}
					}
					//if ($website == 1) {
						echo "<script>
							var links = document.getElementsByTagName(\"a\");
							for(var i = 0; i < links.length; i++) {
								if (links[i].href.substring(0, 11) == \"dsc://view/\") {
									links[i].href = links[i].href.replace(\"dsc://view/\", \"./gameinfo.php?appid=\");
								}
							}
						</script>";
					//}
				}
			} else {
				echo "Wrong appID!";
				mysqli_close($link);
				exit;
			}
			mysqli_close($link);
			exit;
		//} else {
		//	$strupd = mysqli_query($link, "INSERT INTO ds__vb_strikes (striketime, strikeip, username) VALUES (".time().", \"".$_SERVER['REMOTE_ADDR']."\", \"".mysqli_real_escape_string($link, $logintocheck)."\")");
		//	echo "Wrong password!";
		//	mysqli_close($link);
		//	exit;
		//}
	//}
	mysqli_close($link);
}

?>