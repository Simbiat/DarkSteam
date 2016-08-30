<?php
require_once('./commonfunc.php');

require_once "../config.php";


// #######################################################################
// ######################## START MAIN SCRIPT ############################
// #######################################################################


if ($showpn = capcu_fetch("dsc_pns")) {
	require_once('./css.php');
	echo $showpn;
} else {
	$showpn="";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$newsget1 = mysqli_query($link, "SELECT * FROM ds__dspatchnotes order by id DESC");
	if (mysqli_num_rows($newsget1)) {
		require_once('./css.php');
$showpn=$showpn. "<title>Changelog</title><script type=\"text/javascript\">
 
function toggle2(id, link) {
  var e = document.getElementById(id);
 
  if (e.style.display == \"\") {
    e.style.display = \"none\";
  } else {
    e.style.display = \"\";
  }
}
 
</script>";
		$latest=1;
		while ($row = mysqli_fetch_array($newsget1, MYSQLI_ASSOC)){
			if ($latest == 1) {
				$showpn=$showpn. "<a href=\"#\" onclick=\"toggle2('".$row['version']."', this)\">v".$row['version']."</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=silver size=1><i>(".date("d.m.Y", $row['date']).")</i></font><BR><div id=\"".$row['version']."\">".nl2br($row['notes'])."</div><BR>";
				$latest=0;
			} else {
				$showpn=$showpn. "<a href=\"#\" onclick=\"toggle2('".$row['version']."', this)\">v".$row['version']."</a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<font color=silver size=1><i>(".date("d.m.Y", $row['date']).")</i></font><BR><div id=\"".$row['version']."\" style=\"display:none\">".nl2br($row['notes'])."</div><BR>";
			}
		}
	}
	mysqli_close($link);
}
echo $showpn;
capcu_store("dsc_pns", $showpn, 86400);
}
?>