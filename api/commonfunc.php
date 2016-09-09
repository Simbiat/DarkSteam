<?php
/*
$allowsdirs = array(
"C:\Program Files (x86)\Steam\steamapps\common",
"C:\Program Files (x86)\Steam\depotcache"
);
$allowsdirsl = array(
"C:\Program Files (x86)\Steam\steamapps\common\\",
"C:\Program Files (x86)\Steam\depotcache\\"
);
$allowsdirsm = array(
"C:\Program Files (x86)\Steam\steamapps\\",
"C:\Program Files (x86)\Steam\depotcache\\"
);
*/
$allowsdirs = array();
$allowsdirsl = array();
$allowsdirsm = array();

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

function startsWith($haystack, $needle)
{
    return $needle === "" || strpos($haystack, $needle) === 0;
}

function endsWith($haystack, $needle)
{
    return $needle === "" || substr($haystack, -strlen($needle)) === $needle;
}

function FileSizeConvert($bytes)
 {
     $bytes = floatval($bytes);
         $arBytes = array(
             0 => array(
                 "UNIT" => "TB",
                 "VALUE" => pow(1024, 4)
             ),
             1 => array(
                 "UNIT" => "GB",
                 "VALUE" => pow(1024, 3)
             ),
             2 => array(
                 "UNIT" => "MB",
                 "VALUE" => pow(1024, 2)
             ),
             3 => array(
                 "UNIT" => "KB",
                 "VALUE" => 1024
             ),
             4 => array(
                 "UNIT" => "B",
                 "VALUE" => 1
             ),
         );

     foreach($arBytes as $arItem)
     {
         if($bytes >= $arItem["VALUE"])
         {
             $result = $bytes / $arItem["VALUE"];
             $result = str_replace(".", "," , strval(round($result, 2)))." ".$arItem["UNIT"];
             break;
         }
     }
     return $result;
 }


function checkRemoteFile($url)
{
    $ch = curl_init();
    curl_setopt($ch, CURLOPT_URL,$url);
    // don't download content
    curl_setopt($ch, CURLOPT_NOBODY, 1);
    curl_setopt($ch, CURLOPT_FAILONERROR, 1);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, 1);
    if(curl_exec($ch)!==FALSE)
    {
        return true;
    }
    else
    {
        return false;
    }
}
function capcu_delete($filename) {
	if (extension_loaded('apcu') === true) {
		apcu_delete("ss_gameinfo".$appid);
	} else {
		if (file_exists("./cache/".$filename.".txt")) {
			@unlink("./cache/".$filename.".txt");
		}
	}
}
function capcu_store($varname, $vardata, $timestore) {
	if (extension_loaded('apcu') === true) {
		apcu_store($varname, $vardata, $timestore);
	} else {
		if (!is_dir("./cache")) {
			mkdir("./cache");
		}
		@file_put_contents("./cache/".$varname.".txt", $vardata);
	}
}
function capcu_fetch($varname) {
	if (extension_loaded('apcu') === true) {
		return apcu_fetch($varname);
	} else {
		if (time()-filemtime($filename) > 86400) {
			return false;
		} else {
			return file_get_contents("./cache/".$varname.".txt");
		}
	}
}
?>