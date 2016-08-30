<?php
require_once('./commonfunc.php');

if ($showmd5bin = capcu_fetch("dsc_md5binpub")) {
	require_once('./css.php');
	echo $showmd5bin;
} else {
	$showmd5bin="<title>Secondary libraries for DarkSteam Client</title>Below libraries are to be put in dscbin folder and are required for the client to work correctly:<br><Br><table><tr><td><b>Filename</b></td><td><b>md5</b></td><td><b>Size</b></td></tr>";
require_once('./css.php');
$bindir=".\dscbin\\";
if ($handle = opendir($bindir)) {
    while (false !== ($entry = readdir($handle))) {
        if ($entry != "." && $entry != "..") {
            $showmd5bin=$showmd5bin. "<tr><td><a target=_self href=\"./bindown.php?file=".encrypt($entry)."\">".$entry."</a></td><td>".md5_file($bindir.$entry)."</td><td>".FileSizeConvert(filesize($bindir.$entry))."</td></tr>";
        }
    }
    closedir($handle);
}
$showmd5bin=$showmd5bin."</table>";
echo $showmd5bin;
capcu_store("dsc_md5binpub", $showmd5bin, 86400);
}
?>