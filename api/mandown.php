<?php
require_once('./commonfunc.php');


if (empty($_GET['file'])) {
	echo "No filename provided!";
	exit;
} else {
	$file=Trim(Decrypt($_GET['file']));
}
if (empty($_GET['offset'])) {
	$offset = 0;
} else {
	$offset = $_GET['offset'];
}

if (endsWith($file, "manifest") === false and endsWith($file, "acf") === false and endsWith($file, "ncf") === false) {
	echo "Forbidden extension!";
	exit;
}
$filename=$file;
foreach ($allowsdirsm as $path) {
	if (file_exists($path.$file)) {
		$filename=$path.$file;
	}
}
if ($filename == $file) {
	Echo "File does not exist!";
	exit;
}


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
	if (!endsWith($filename, "acf")) {
		header('Accept-Ranges: bytes');
	}
	set_time_limit(0);
	if (endsWith($filename, "acf")) {
		$lines = file($filename);
		foreach ($lines as $line) {
			if (stripos($line, "LastOwner") === false and stripos($line, "userid") === false) {
    				echo $line;
			}
		}
	} else {
		if ($fd = fopen ($filename, "r")) {
			fseek($fd, $offset);
			while(!feof($fd)) {
				$buffer = fread($fd, 1024);
				echo $buffer;
			}
		}
	}
}
exit;
?>