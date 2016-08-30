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
require_once(DIR . '/includes/cron/darksteamopstorrent.php');
require_once(DIR . '/includes/cron/darksteamopsut.php');


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
$torrentsdir="C:/torrents/";
//$trackers=array("udp://tracker.publicbt.com:80/announce", "udp://tracker.openbittorrent.com:80/announce");
//$trackers="udp://tracker.publicbt.com:80/announce";
$trackers="";
$hashkey="H@19hKeyF@r20orr5n!";
$origdowndir="d:\\Stuff\\Temp\\";



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



// ########################## GenAva RESET ############################
$price=0;
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$acfrowcheck = mysqli_query($link, "SELECT ActiveDepots, AppID FROM ds__dsgamelist");
	if (mysqli_num_rows($acfrowcheck)) {
		while ($row = mysqli_fetch_array($acfrowcheck, MYSQLI_ASSOC)) {
			$appid=$row['AppID'];
			$ActiveDepotslist=$row['ActiveDepots'];
			$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$appid);
			$fullappinfo=json_decode($jsonstring, true);
			if ($fullappinfo[$appid]['success']) {
				$price=$price + $fullappinfo[$appid]['data']['price_overview']['initial'];
				if ($ActiveDepotslist != "") {
					$explodedmanifests = explode(",", $ActiveDepotslist, 999999999);
					foreach ($explodedmanifests as $explodeddeps) {
						$explodedmanifests2 = explode("_", $explodeddeps, 100);
						if ($explodedmanifests2[0] != $appid) {
							$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".$explodedmanifests2[0]);
							$fullappinfo=json_decode($jsonstring, true);
							if ($fullappinfo[$explodedmanifests2[0]]['success']) {
								$price=$price + $fullappinfo[$appid]['data']['price_overview']['initial'];
							}
						} else {
							if (substr($explodedmanifests2[0], 0, -1)."0" != $appid) {
								$jsonstring=file_get_contents("http://store.steampowered.com/api/appdetails/?cc=us&appids=".substr($explodedmanifests2[0], 0, -1)."0");
								$fullappinfo=json_decode($jsonstring, true);
								if ($fullappinfo[substr($explodedmanifests2[0], 0, -1)."0"]['success']) {
									$price=$price + $fullappinfo[$appid]['data']['price_overview']['initial'];
								}
							}
						}
					}
				}
			}
		}
	}
	$shinp = mysqli_query($link, "UPDATE ds__dsstaticvars SET parameter=\"".substr($price, 0, -2).".".substr($price, -2)."\" WHERE id=\"1\"");
}
mysqli_close($link);

log_cron_action("DS price counted at " . date("H:i", time()), $nextitem);

/*======================================================================*\
|| ####################################################################
|| # 
|| # CVS: $RCSfile$ - $Revision: 62096 $
|| ####################################################################
\*======================================================================*/
?>