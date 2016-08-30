<?php
if ($showmd5bin = capcu_fetch("dsc_md5bin")) {
	echo $showmd5bin;
} else {
	$showmd5bin="";
$bindir=".\dscbin\\";
if ($handle = opendir($bindir)) {
    while (false !== ($entry = readdir($handle))) {
        if ($entry != "." && $entry != "..") {
            $showmd5bin=$showmd5bin. $entry.";!!!;".md5_file($bindir.$entry).";!!!;".filesize($bindir.$entry)."<BR>";
        }
    }
    closedir($handle);
}
echo $showmd5bin;
capcu_store("dsc_md5bin", $showmd5bin, 86400);
}
?>