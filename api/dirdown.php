<?php
require_once('./commonfunc.php');

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
//require_once('../global.php');
require_once('../includes/functions_login.php');
chdir ($curdir);




// ######################### REQUIRE BACK-END ############################
$host=$vbulletin->config['MasterServer']['servername'] . ":" . $vbulletin->config['MasterServer']['port'];
$username=$vbulletin->config['MasterServer']['username']; // Mysql username
$password=$vbulletin->config['MasterServer']['password']; // Mysql password
$db_name=$vbulletin->config['Database']['dbname']; // Database name
$settingslist="settings_tray, settings_auto, settings_logs, settings_path, settings_autoscroll, settings_shoutbox, settings_shouttimer, settings_shoutcount, settings_perfileprog, settings_statenab, settings_sdateformat, settings_lateadd, settings_lateupd, settings_invis, settings_gamedet, settings_downres, settings_resx, settings_resy, settings_accupdch, settings_shoutsound, settings_altshupdsound, settings_pmsound, settings_maxretries, settings_win7progress, settings_win7shake, settings_hourupdcheck, settings_hourgamcheck, settings_linkintercept, settings_clicksnddis";


// #######################################################################
// ######################## START MAIN SCRIPT ############################
// #######################################################################
$website=0;
$unregistered=0;
if (empty($_GET['login'])) {
	$logintocheck=$vbulletin->userinfo['username'];
	$website=1;
	if ($logintocheck == "Unregistered") {
		$unregistered=1;
	}
} else {
	if (empty($_GET['pass'])) {
		$passtocheck=$vbulletin->userinfo['password'];
		$website=1;
	} else {
		$logintocheck=Trim(Decrypt($_GET['login']));
		$passtocheck=Trim(Decrypt($_GET['pass']));
	}
}
if (empty($_GET['filename'])) {
	echo "No filename provided!";
	exit;
} else {
	$filename=Trim(Decrypt($_GET['filename']));
	$fileallowed=0;
	foreach ($allowsdirs as $path) {
		if (startsWith($filename, $path)) {
			$fileallowed=1;
		}
	}
	if ($fileallowed == 0) {
		echo "Forbidden file!";
		exit;
	}	
}
if (empty($_GET['offset'])) {
	$offset = 0;
} else {
	$offset = $_GET['offset'];
}


/*
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$passcheck = mysqli_query($link, "SELECT usergroupid, membergroupids, password FROM ds__vb_user WHERE username=\"".mysqli_real_escape_string($link, $logintocheck)."\"");
	if (mysqli_num_rows($passcheck) or $unregistered == 1) {
		while ($row = mysqli_fetch_array($passcheck, MYSQLI_ASSOC)) {
			$md5pass=$row['password'];
			$usergroupid=$row['usergroupid'];
			$membership=$row['membergroupids'];
			if ($usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
				if ($usergroupid == 13) {
					$usergroupid=13;
				} else {
					if (strpos($membership, "13") === false) {
						$usergroupid=2;
					} else {
						$usergroupid=13;
					}
				}
			}
		}
*/
		if ($website == 1) {
			$usergroupid=$vbulletin->userinfo['usergroupid'];
			$membership=$vbulletin->userinfo['membergroupids'];
			if ($vbulletin->userinfo['userid'] and $usergroupid != 1 and $usergroupid != 3 and $usergroupid != 4 and $usergroupid != 8) {
				if ($usergroupid == 13) {
					$usergroupid=13;
				} else {
					if (strpos($membership, "13") === false) {
						$usergroupid=2;
					} else {
						$usergroupid=13;
					}
				}
			} else {
				Echo "Forbidden file!";
				exit;
			}
		}
		if ($passtocheck == Decrypt(Encrypt($md5pass)) or $website == 1) {
			//mysqli_close($link);
			if (is_file($filename)) {
				$basename = basename($filename);
				$length   = sprintf("%u", filesize($filename));
				if ( isset($_SERVER['HTTP_RANGE']) ) {
					$partialContent = true;
					preg_match('/bytes=(\d+)-(\d+)?/', $_SERVER['HTTP_RANGE'], $matches);
					$offset = intval($matches[1]);
					$length = intval($matches[2]) - $offset;
				} else {
					$partialContent = false;
				}
				if ( $partialContent ) {
					header('HTTP/1.1 206 Partial Content');
					header('Content-Range: bytes ' . $offset . '-' . ($offset + $length) . '/' . $filesize);
				}
				header('Content-Description: File Transfer');
				header('Content-Type: application/octet-stream');
				header('Content-Disposition: attachment; filename="' . $basename . '"');
				header('Content-Transfer-Encoding: binary');
				header('Connection: Keep-Alive');
				header('Expires: 0');
				header('Cache-Control: must-revalidate, post-check=0, pre-check=0');
				header('Pragma: public');
				header('Content-Length: ' . $length);
				header('Accept-Ranges: bytes');
				set_time_limit(0);
				//readfile($filename);
				if ($fd = fopen ($filename, "r")) {
					fseek($fd, $offset);
					while(!feof($fd)) {
						$buffer = fread($fd, 1024);
						echo $buffer;
					}
				}
			}
			exit;
		} else {
			//$strupd = mysqli_query($link, "INSERT INTO ds__vb_strikes (striketime, strikeip, username) VALUES (".time().", \"".$_SERVER['REMOTE_ADDR']."\", \"".mysqli_real_escape_string($link, $logintocheck)."\")");
			echo "Wrong password!";
			mysqli_close($link);
			exit;
		}
/*
	}
	mysqli_close($link);
}
*/
?>