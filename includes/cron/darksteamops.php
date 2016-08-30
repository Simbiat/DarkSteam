<?php
/*======================================================================*\
|| #################################################################### ||
|| # vBulletin 4.2.0 Patch Level 3
|| # ---------------------------------------------------------------- # ||
|| # Copyright ©2000-2012 vBulletin Solutions Inc. All Rights Reserved. ||
|| # This file may not be redistributed in whole or significant part. # ||
|| # ---------------- VBULLETIN IS NOT FREE SOFTWARE ---------------- # ||
|| # http://www.vbulletin.com | http://www.vbulletin.com/license.html # ||
|| #################################################################### ||
\*======================================================================*/

// ######################## SET PHP ENVIRONMENT ###########################
error_reporting(E_ALL & ~E_NOTICE);

if (!is_object($vbulletin->db))
{
    exit;
}
@set_time_limit(0);
@ignore_user_abort(1);

// ##################### DEFINE IMPORTANT CONSTANTS #######################
define('CVS_REVISION', '$RCSfile$ - $Revision: 62096 $');
define('NOZIP', 1);

// #################### PRE-CACHE TEMPLATES AND DATA ######################
$phrasegroups = array('forum', 'cpuser', 'forumdisplay', 'prefix');
$specialtemplates = array();


// ########################## REQUIRE BACK-END ############################
//require_once(DIR . '/akuma/global.php');
require_once(DIR . '/includes/adminfunctions.php');
require_once(DIR . '/includes/init.php');
require_once(DIR . '/includes/adminfunctions_template.php');
require_once(DIR . '/includes/adminfunctions_forums.php');
require_once(DIR . '/includes/adminfunctions_prefix.php');
require_once(DIR . '/includes/functions_databuild.php');


// ########################################################################
// ######################### START MAIN SCRIPT ############################
// ########################################################################

print_cp_header($vbphrase['forum_manager']);


($hook = vBulletinHook::fetch_hook('forumadmin_start')) ? eval($hook) : false;

// ###################### Start add #######################
	$vbulletin->input->clean_array_gpc('r', array(
		'forumid'			=> TYPE_UINT,
		'defaultforumid'	=> TYPE_UINT,
		'parentid'			=> TYPE_UINT

	));


// ########################## SETTINGS AND CONNECTION ############################
log_cron_action("DS Ops started at " . date("H:i", time()), $nextitem);
$host=$vbulletin->config['MasterServer']['servername'] . ":" . $vbulletin->config['MasterServer']['port'];
$username=$vbulletin->config['MasterServer']['username']; // Mysql username
$password=$vbulletin->config['MasterServer']['password']; // Mysql password
$db_name=$vbulletin->config['Database']['dbname']; // Database name
//$torrentsdir="C:/torrents/";
//$trackers="http://a12.net.ru/api/announce";
//$trackers="udp://tracker.openbittorrent.com:80/announce udp://tracker.publicbt.com:80/announce";
//$hashkey="H@19hKeyF@r20orr5n!";
//$origdowndir="d:\\Stuff\\Temp\\";
$apctoclear=0;
//$torpluscreatcmd="\"C:/Python33/python.exe\" \"C:/torcreat/py3createtorrent.py\" -P -f ";
//$torcreatcmd="\"C:/Python33/python.exe\" \"C:/torcreat/py3createtorrent.py\" -f ";
//$delugepath="\"C:/Deluge/deluge-console.exe\"";
//$delugeresume="C:/Users/user/AppData/Roaming/deluge/state/torrents.state";
//utorrentapisettings
//$utip="127.0.0.1";
//$utport="13291";
//$utuser="dsbot";
//$utpass="dsbot";


function real_filesize($file_path)
{
    $fs = new COM("Scripting.FileSystemObject");
    return $fs->GetFile($file_path)->Size;
}
function getTitle($Url){
    $str = file_get_contents($Url);
    if(strlen($str)>0){
        preg_match("/\<title\>(.*)\<\/title\>/",$str,$title);
        return $title[1];
    }
}
function multi_implode($array, $glue) {
	$ret = '';
	foreach ($array as $item) {
		if (is_array($item)) {
			$ret .= multi_implode($item, $glue) . $glue;
		} else {
			if (!is_int($item) and !ctype_digit($item)) {
				$ret .= $item . $glue;
			}
		}
	}
		$ret = substr($ret, 0, 0-strlen($glue));
		return $ret;
}

function aI1filter($string) {
	//return strpos($string, 'aI1') === false;
	if (strpos($string, '.torrent') !== false and strpos($string, '.torrentmanager') === false) {
		return true;
	} elseif (strpos($string, 'S\'') === 0 and strlen($string) == 43) {
		return true;
	} else {
		return  false;
	}
}

// ####################### CRYPT MODULE ###########################
$rijnKey = "\x1\x2\x3\x4\x5\x6\x7\x8\x9\x10\x11\x12\x13\x14\x15\x16";
$rijnIV = "\x1\x2\x3\x4\x5\x6\x7\x8\x9\x10\x11\x12\x13\x14\x15\x16";
function Decrypt($s){
global $rijnKey, $rijnIV;

if ($s == "") { return $s; }

// Turn the cipherText into a ByteArray from Base64
try {
$s = str_replace("BIN00101011BIN", "+", $s);
$s = base64_decode($s);
$s = mcrypt_decrypt(MCRYPT_RIJNDAEL_128, $rijnKey, $s, MCRYPT_MODE_CBC, $rijnIV);
} catch(Exception $e) {
// There is a problem with the string, perhaps it has bad base64 padding
// Do Nothing
}
return $s;
}

function Encrypt($s){
global $rijnKey, $rijnIV;

// Have to pad if it is too small
$block = mcrypt_get_block_size(MCRYPT_RIJNDAEL_128, 'cbc');
$pad = $block - (strlen($s) % $block);
$s .= str_repeat(chr($pad), $pad);

$s = mcrypt_encrypt(MCRYPT_RIJNDAEL_128, $rijnKey, $s, MCRYPT_MODE_CBC, $rijnIV);
$s = base64_encode($s);
$s = str_replace("+", "BIN00101011BIN", $s);
return $s;
}


function find_all_files($dir, $appid, $output) { 
	$root = scandir($dir); 
	foreach($root as $value) { 
		if($value === '.' || $value === '..') {continue;} 
		if(is_file("$dir/$value")) {file_put_contents($output, "1 ".$appid." 1 ".encrypt($dir."/".$value)." ".md5_file($dir."/".$value)." ".filesize($dir."/".$value)."\r\n", FILE_APPEND);continue;} 
		if(is_dir("$dir/$value")) {find_all_files("$dir/$value", $appid, $output);continue;} 
	} 
	unset($value);
	return $result; 
} 

function count_files($path) {
	// (Ensure that the path contains an ending slash)
	$file_count = 0;
	$dir_handle = opendir($path);
	if (!$dir_handle) return -1;
	while ($file = readdir($dir_handle)) {
		if ($file == '.' || $file == '..') continue;
		if (is_dir($path . $file)){      
			$file_count += count_files($path . $file . DIRECTORY_SEPARATOR);
		} else {
			$file_count++; // increase file count
		}
	}
	closedir($dir_handle);
	return $file_count;
}



$acfregpath = "C:/Program Files (x86)/Steam/steamapps/";
$regusavail = 0;
require(DIR . '/includes/cron/darksteamopsupdater.php');
log_cron_action("DS Ops: ACF Reg3 list updated at " . date("H:i", time()), $nextitem);



// ########################## GenAva RESET ############################
Echo "Clearing status of ACF files...<br>";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$acfclear = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.gamedesc=\"\" WHERE ds__dsgamelist.gamedesc LIKE \"%Steam Database record for%\"");
	$acfrowcheck = mysqli_query($link, "SELECT * FROM ds__dsgamelist WHERE UpToDate=1");
	if (mysqli_num_rows($acfrowcheck)) {
		while ($row = mysqli_fetch_array($acfrowcheck, MYSQLI_ASSOC)) {
			$realpath=$row['realpath'];
			$torrnametosave=basename($realpath);
			//$torrpathtosave=str_replace("\\", "%5C", str_replace(":", "%3A", str_replace("//", "/", str_replace($torrnametosave, "", $realpath))));
			$filepath = explode("\\", $row['PathToACF'], 100);
			if (!file_exists(str_replace("//", "/", str_replace("common/".$torrnametosave, "", $realpath)).$filepath[count($filepath)-1])) {
				$acfclear = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.GenAva=0 WHERE ds__dsgamelist.PathToACF=\"".mysqli_real_escape_string($link, $row['PathToACF'])."\"");
				echo $row['GameName']." marked as <b>unavailable</b><br>";
				$apctoclear=1;
			} else {
				$gamestate=4;
				if ($acffile = @file(str_replace("//", "/", str_replace("common/".$torrnametosave, "", $realpath)).$filepath[count($filepath)-1])) {
					foreach ($acffile as $acfline) {
						$explline = explode('"', $acfline);
						if (strcasecmp($explline[1], "StateFlags") == 0) {
							$gamestate = $explline[3];
						}
					}
					if ($gamestate != 4) {
						$acfclear = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.GenAva=0 WHERE ds__dsgamelist.PathToACF=\"".mysqli_real_escape_string($link, $row['PathToACF'])."\"");
						echo $row['GameName']." marked as <b>unavailable</b><br>";
						$apctoclear=1;
					}
				}
				if ($gamestate == 4) {
					if (!file_exists(str_replace("//", "/", str_replace("common/".$torrnametosave, "", $realpath))."downloading/".$row['appID'])) {
						$acfclear = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.GenAva=1 WHERE ds__dsgamelist.PathToACF=\"".mysqli_real_escape_string($link, $row['PathToACF'])."\"");
						echo $row['GameName']." marked as <b>available</b><br>";
						$apctoclear=1;
					} else {
						$acfclear = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.GenAva=0 WHERE ds__dsgamelist.PathToACF=\"".mysqli_real_escape_string($link, $row['PathToACF'])."\"");
						echo $row['GameName']." marked as <b>unavailable</b><br>";
						$apctoclear=1;
					}
				}
			}
		}
	}
}
mysqli_close($link);
if ($apctoclear=1) {
	if (extension_loaded('apcu') === true) {
		$toDelete = new APCIterator("user", "/^dsc_gamelist/", apcu_ITER_VALUE);
		apcu_delete($toDelete);
		$toDelete = new APCIterator("user", "/^dsc_gamelist_web/", apcu_ITER_VALUE);
		apcu_delete($toDelete);
	}
}

log_cron_action("DS Ops: ACF availability updated at " . date("H:i", time()), $nextitem);
exit;




$origmemlim=ini_get("memory_limit");
ini_set("memory_limit","1024M");
// ########################## Torrent check ############################
log_cron_action("DS Ops: Torrent check started at " . date("H:i", time()), $nextitem);
Echo "Checking torrents' existence...<br>";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$acfrowcheck = mysqli_query($link, "SELECT appID, torrname FROM ds__dsgamelist WHERE GenAva=1 AND misstorr=0");
	if (mysqli_num_rows($acfrowcheck)) {
		while ($row = mysqli_fetch_array($acfrowcheck, MYSQLI_ASSOC)) {
			$realpath=$row['realpath'];
			if (empty($row['torrname']) === true) {
				$markasmistorr = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.misstorr=1 WHERE appID=".$row['appID']);
			} else {
				if (!file_exists($row['torrname'])) {
					$markasmistorr = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.misstorr=1 WHERE appID=".$row['appID']);
				} else {
					$filecheck = file($row['torrname']);
					if (end($filecheck) !== "end") {
						while (file_exists($row['torrname'])) {
							unlink($row['torrname']);
						}
						$markasmistorr = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.misstorr=1 WHERE appID=".$row['appID']);
					}
					unset($filecheck);
				}
			}
		}
	}
	log_cron_action("DS Ops: Torrent check by file completed at " . date("H:i", time()), $nextitem);
	$acfrowcheck = mysqli_query($link, "SELECT torrname FROM ds__dsgamelist WHERE misstorr=1");
	if (mysqli_num_rows($acfrowcheck)) {
		while ($row = mysqli_fetch_array($acfrowcheck, MYSQLI_ASSOC)) {
			while (file_exists($row['torrname'])) {
				unlink($row['torrname']);
			}
		}
	}
}
mysqli_close($link);
log_cron_action("DS Ops: Torrent check completed at " . date("H:i", time()), $nextitem);




// ########################## Torrent creator ############################
Echo "Generating torrents...<br>";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$acfrowcheck = mysqli_query($link, "SELECT appID, GameName, realpath FROM ds__dsgamelist WHERE GenAva=1 AND misstorr=1 AND tirrinpr=0 ORDER BY CommonFolderSize ASC");
	if (mysqli_num_rows($acfrowcheck)) {
		while ($row = mysqli_fetch_array($acfrowcheck, MYSQLI_ASSOC)) {
			$realpath=$row['realpath'];
			$appid=$row['appID'];
			$torrnametosave=basename($realpath);
			//$torrnametosave=str_replace("'", "___", basename($realpath));
			$torrnamedeluge=str_replace(" ", "' '", $torrnametosave);
			//$torrpathtosave=str_replace("\\", "%5C", str_replace(":", "%3A", str_replace("//", "/", str_replace($torrnametosave, "", $realpath))));
			$torrpathtosave=str_replace("//", "/", str_replace(basename($realpath), "", $realpath));
			$torrneedscr=0;
			$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
			if (!$link2) {
				die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
			} else {
				$acfrowcheck2 = mysqli_query($link2, "SELECT appID, realpath FROM ds__dsgamelist WHERE GenAva=1 AND misstorr=1 AND tirrinpr=0 AND appID=".$row['appID']);
				if (mysqli_num_rows($acfrowcheck2)) {
					$torrneedscr=1;
				} else {
					$torrneedscr=0;
				}
				mysqli_close($link2);
			}
			if ($torrneedscr==1) {
				if (file_exists($realpath)) {
					log_cron_action("DS Ops: DLST creation started for ".$row['GameName']." at " . date("H:i", time()), $nextitem);
					$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
					if (!$link2) {
						die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
					} else {
						$marktorrinp = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.tirrinpr=1 WHERE realpath=\"".$realpath."\"");
						mysqli_close($link2);
					}
					$filescount = count_files($realpath."/");
					$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
					$depcount = mysqli_query($link2, "SELECT PathToACF, ActiveDepots FROM ds__dsgamelist WHERE realpath=\"".$realpath."\"");
					if (mysqli_num_rows($depcount)) {
						while ($deprow = mysqli_fetch_array($depcount, MYSQLI_ASSOC)) {
							if ($deprow['PathToACF'] != "") {
								$filescount = $filescount + 1;
							}
							if ($deprow['ActiveDepots'] != "") {
								$deparray=explode(",", $deprow['ActiveDepots']);
								$filescount = $filescount + count($deparray);
							}
						}
					}
					file_put_contents($torrentsdir.$torrnametosave.".dlst", "total: ".$filescount."\r\n");
					$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
					$depcount = mysqli_query($link2, "SELECT appID, PathToACF, ActiveDepots FROM ds__dsgamelist WHERE realpath=\"".$realpath."\"");
					if (mysqli_num_rows($depcount)) {
						while ($deprow = mysqli_fetch_array($depcount, MYSQLI_ASSOC)) {
							if ($deprow['PathToACF'] != "") {
								file_put_contents($torrentsdir.$torrnametosave.".dlst", "1 ".$deprow['appID']." 3 ".encrypt($deprow['PathToACF'])."\r\n", FILE_APPEND);
							}
							if ($deprow['ActiveDepots'] != "") {
								$deparray=explode(",", $deprow['ActiveDepots']);
								foreach ($deparray as &$depel) {
									file_put_contents($torrentsdir.$torrnametosave.".dlst", "1 ".$deprow['appID']." 2 ".encrypt($depel)."\r\n", FILE_APPEND);
								}
								unset($depel);
							}
						}
					}
					find_all_files($realpath, $appid, $torrentsdir.$torrnametosave.".dlst");
					$linescount = count(file($torrentsdir.$torrnametosave.".dlst"));
					if ($filescount === ($linescount - 1)) {
						file_put_contents($torrentsdir.$torrnametosave.".dlst", "end", FILE_APPEND);
						$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
						if (!$link2) {
							die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
						} else {
							$updateinlist = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.tirrinpr=0, ds__dsgamelist.misstorr=0, ds__dsgamelist.torrname=\"".$torrentsdir.$torrnametosave.".dlst\" WHERE realpath=\"".$realpath."\"");
							mysqli_close($link2);
						}
						echo "DLST for ".$row['GameName']." created<br>";
						log_cron_action("DS Ops: DLST created for ".$row['GameName']." at " . date("H:i", time()), $nextitem);
					} else {
						while (file_exists($torrentsdir.$torrnametosave.".dlst")) {
							unlink($torrentsdir.$torrnametosave.".dlst");
						}
						$link2 = mysqli_connect("$host", "$username", "$password", "$db_name");
						if (!$link2) {
							die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
						} else {
							$updateinlist = mysqli_query($link, "UPDATE ds__dsgamelist SET ds__dsgamelist.tirrinpr=0, ds__dsgamelist.misstorr=1 WHERE realpath=\"".$realpath."\"");
							mysqli_close($link2);
						}
						echo "DLST for ".$row['GameName']." failed<br>";
						log_cron_action("DS Ops: DLST failed for ".$row['GameName']." at " . date("H:i", time()), $nextitem);
					}
					unset($linescount);
					unset($filescount);
				}
			} else {
				echo "Torrent for ".$row['GameName']." is up-to-date<br>";
			}
		}
	}
}
mysqli_close($link);
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$updateinlist = mysqli_query($link, "UPDATE ds__dsstaticvars SET parameter=0 WHERE id=2");
	mysqli_close($link);
}
log_cron_action("DS Ops: Torrent maker completed " . date("H:i", time()), $nextitem);


log_cron_action("DS Ops ended at " . date("H:i", time()), $nextitem);
ini_set("memory_limit",$origmemlim);


/*======================================================================*\
|| ####################################################################
|| # 
|| # CVS: $RCSfile$ - $Revision: 62096 $
|| ####################################################################
\*======================================================================*/
?>
