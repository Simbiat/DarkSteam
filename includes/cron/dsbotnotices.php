<?php
ini_set( "display_errors", 1);
ini_set( "display_warnings", 1);
ini_set( "display_notices", 1);


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
//return preg_replace('/[^(u25D0-u25FF)]*/','', preg_replace('/[^(u25A0-u25CF)]*/','', $s));
$block = mcrypt_get_block_size(MCRYPT_RIJNDAEL_128, 'cbc');
$pad = ord($s[($len = strlen($s)) - 1]);
return substr($s, 0, strlen($s) - $pad);
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



// ####################### SET PHP ENVIRONMENT ###########################
error_reporting(E_ALL & ~E_NOTICE);

// #################### DEFINE IMPORTANT CONSTANTS #######################

define('THIS_SCRIPT', 'dscindex');
define('CSRF_PROTECTION', true);  
// change this depending on your filename

// ################### PRE-CACHE TEMPLATES AND DATA ######################
// get special phrase groups
$phrasegroups = array();

// get special data templates from the datastore
$specialtemplates = array();

// pre-cache templates used by all actions
$globaltemplates = array('dscindex',
);

// pre-cache templates used by specific actions
//$actiontemplates = array();
$actiontemplates = array(
	'lostpw' => array(
		'lostpw',
		'humanverify'
	)
);





// ######################### REQUIRE BACK-END ############################
// if your page is outside of your normal vb forums directory, you should change directories by uncommenting the next line
// chdir ('/path/to/your/forums');
//require_once('./global.php');
$curdir = getcwd ();
require_once('../../global.php');
require_once('../functions_login.php');
chdir ($curdir);




// ######################### REQUIRE BACK-END ############################
$host=$vbulletin->config['MasterServer']['servername'] . ":" . $vbulletin->config['MasterServer']['port'];
$username=$vbulletin->config['MasterServer']['username']; // Mysql username
$password=$vbulletin->config['MasterServer']['password']; // Mysql password
$db_name=$vbulletin->config['Database']['dbname']; // Database name


// #######################################################################
// ######################## START MAIN SCRIPT ############################
// #######################################################################


$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$shownotices="";
	$noticegrab = mysqli_query($link, "SELECT sticky FROM ds__vb_dbtech_vbshout_instance");
	if (mysqli_num_rows($noticegrab)) {
		while ($row = mysqli_fetch_array($noticegrab, MYSQLI_ASSOC)){
			$shownotices=$shownotices. $row['sticky']."<br><br>";
		}
	}
	$noticegrab = mysqli_query($link, "SELECT varname, text FROM ds__vb_phrase WHERE varname LIKE \"notice_%_html\" order by phraseid ASC");
	if (mysqli_num_rows($noticegrab)) {
		while ($row = mysqli_fetch_array($noticegrab, MYSQLI_ASSOC)){
			if ($row['varname'] !== "notice_1_html") {
				$shownotices=$shownotices. $row['text']."<br><br>";
			}
		}
	}
	$shownotices=$shownotices."<font color=gold>I am a bot, so do not bother speaking to me - I will not answer</font>";

	$shinpcheck = mysqli_query($link, "SELECT message FROM ds__vb_dbtech_vbshout_shout WHERE type=1 AND chatroomid="."0"." AND instanceid=1 ORDER BY shoutid DESC LIMIT 10");
	if (mysqli_num_rows($shinpcheck)) {
		$canpost=1;
		while ($row = mysqli_fetch_array($shinpcheck, MYSQLI_ASSOC)){
			if ($row['message'] == $shownotices) {
				$canpost=0;
				break;
			}
		}
		if ($canpost == 1) {
			$shinp = mysqli_query($link, "INSERT INTO ds__vb_dbtech_vbshout_shout (dateline,userid,message,message_raw,type,id,forumid,chatroomid,instanceid) VALUES(\"".time()."\",\"2\",\"".mysqli_real_escape_string($link, $shownotices)."\",\"".mysqli_real_escape_string($link, $shownotices)."\",1,0,0,"."0".",1)");
			$shinp = mysqli_query($link, "UPDATE ds__vb_user SET dbtech_vbshout_shouts = dbtech_vbshout_shouts + 1 WHERE userid=\"2\"");
		}
	}

	$shinpcheck = mysqli_query($link, "SELECT message FROM ds__vb_dbtech_vbshout_shout WHERE type=1 AND chatroomid="."1"." AND instanceid=1 ORDER BY shoutid DESC LIMIT 10");
	if (mysqli_num_rows($shinpcheck)) {
		$canpost=1;
		while ($row = mysqli_fetch_array($shinpcheck, MYSQLI_ASSOC)){
			if ($row['message'] == $shownotices) {
				$canpost=0;
				break;
			}
		}
		if ($canpost == 1) {
			$shinp = mysqli_query($link, "INSERT INTO ds__vb_dbtech_vbshout_shout (dateline,userid,message,message_raw,type,id,forumid,chatroomid,instanceid) VALUES(\"".time()."\",\"2\",\"".mysqli_real_escape_string($link, $shownotices)."\",\"".mysqli_real_escape_string($link, $shownotices)."\",1,0,0,"."1".",1)");
			$shinp = mysqli_query($link, "UPDATE ds__vb_user SET dbtech_vbshout_shouts = dbtech_vbshout_shouts + 1 WHERE userid=\"2\"");
		}
	}

	$shinpcheck = mysqli_query($link, "SELECT message FROM ds__vb_dbtech_vbshout_shout WHERE type=1 AND chatroomid="."2"." AND instanceid=1 ORDER BY shoutid DESC LIMIT 10");
	if (mysqli_num_rows($shinpcheck)) {
		$canpost=1;
		while ($row = mysqli_fetch_array($shinpcheck, MYSQLI_ASSOC)){
			if ($row['message'] == $shownotices) {
				$canpost=0;
				break;
			}
		}
		if ($canpost == 1) {
			$shinp = mysqli_query($link, "INSERT INTO ds__vb_dbtech_vbshout_shout (dateline,userid,message,message_raw,type,id,forumid,chatroomid,instanceid) VALUES(\"".time()."\",\"2\",\"".mysqli_real_escape_string($link, $shownotices)."\",\"".mysqli_real_escape_string($link, $shownotices)."\",1,0,0,"."2".",1)");
			$shinp = mysqli_query($link, "UPDATE ds__vb_user SET dbtech_vbshout_shouts = dbtech_vbshout_shouts + 1 WHERE userid=\"2\"");
		}
	}

	$shinpcheck = mysqli_query($link, "SELECT message FROM ds__vb_dbtech_vbshout_shout WHERE type=1 AND chatroomid="."3"." AND instanceid=1 ORDER BY shoutid DESC LIMIT 10");
	if (mysqli_num_rows($shinpcheck)) {
		$canpost=1;
		while ($row = mysqli_fetch_array($shinpcheck, MYSQLI_ASSOC)){
			if ($row['message'] == $shownotices) {
				$canpost=0;
				break;
			}
		}
		if ($canpost == 1) {
			$shinp = mysqli_query($link, "INSERT INTO ds__vb_dbtech_vbshout_shout (dateline,userid,message,message_raw,type,id,forumid,chatroomid,instanceid) VALUES(\"".time()."\",\"2\",\"".mysqli_real_escape_string($link, $shownotices)."\",\"".mysqli_real_escape_string($link, $shownotices)."\",1,0,0,"."3".",1)");
			$shinp = mysqli_query($link, "UPDATE ds__vb_user SET dbtech_vbshout_shouts = dbtech_vbshout_shouts + 1 WHERE userid=\"2\"");
		}
	}
	mysqli_close($link);
}
?>