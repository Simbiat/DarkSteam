<?php
require_once('./commonfunc.php');

require_once "../config.php";

// #######################################################################
// ######################## START MAIN SCRIPT ############################
// #######################################################################

require_once('./css.php');
if (empty($_GET['faqname'])) {
if ($showfaq = capcu_fetch("dsc_faqlist")) {
	echo $showfaq;
} else {
	$showfaq="";
$showfaq=$showfaq. "<title>F.A.Q.</title>";

function faqproc($faqvarname, $level) {
	global $link;
	global $showfaq;
	$faqroot = mysqli_query($link, "SELECT faqname FROM ds__vb_faq WHERE volatile=0 And faqparent=\"".$faqvarname."\" order by displayorder ASC");
	if (mysqli_num_rows($faqroot)) {
		while ($row = mysqli_fetch_array($faqroot, MYSQLI_ASSOC)){
			$faqtitle = mysqli_query($link, "SELECT text FROM ds__vb_phrase WHERE fieldname=\"faqtitle\" And varname=\"".$row['faqname']."\"");
			if (mysqli_num_rows($faqtitle)) {
				while ($rowname = mysqli_fetch_array($faqtitle, MYSQLI_ASSOC)){
					$faqroot2 = mysqli_query($link, "SELECT faqname FROM ds__vb_faq WHERE volatile=0 And faqparent=\"".$row['faqname']."\" order by displayorder ASC");
					if (mysqli_num_rows($faqroot2)) {
						$showfaq=$showfaq. "<li>".str_repeat("---", $level).$rowname['text']."</li>";
					} else {
						$showfaq=$showfaq. "<li>".str_repeat("---", $level)."<a target=\"faqanswer\" title=\"".$rowname['text']."\" href=\"faq.php?faqname=".$row['faqname']."\">".$rowname['text']."</a></li>";
					}
					faqproc($row['faqname'], $level +1);
				}
			}
		}
	}
}
$showfaq=$showfaq. "
		<script type=\"text/javascript\" src=\"jquery/jquery-2.0.3.min.js\"></script>
		<script src=\"jquery/jquery.fastLiveFilter.js\"></script>
		<script>
			$(function() {
        			$('#faq_input').fastLiveFilter('#faq_list');
    			});
		</script>
	";
		$showfaq=$showfaq. "
<div style=\"overflow: auto; max-height: 720px;\"><table><tr><td style=\"vertical-align: top\" width=30%><div><input alt=\"Search\" id=\"faq_input\" placeholder=\"Type to search\"></div><div style=\"overflow-x:hidden; overflow-y:auto; max-height: 720px;\"><ul id=\"faq_list\">";
$link = mysqli_connect("$host", "$username", "$password", "$db_name");
if (!$link) {
	die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
} else {
	$faqroot = mysqli_query($link, "SELECT faqname FROM ds__vb_faq WHERE volatile=0 And faqparent=\"faqroot\" order by displayorder ASC");
	if (mysqli_num_rows($faqroot)) {
		while ($row = mysqli_fetch_array($faqroot, MYSQLI_ASSOC)){
			$faqtitle = mysqli_query($link, "SELECT text FROM ds__vb_phrase WHERE fieldname=\"faqtitle\" And varname=\"".$row['faqname']."\"");
			if (mysqli_num_rows($faqtitle)) {
				while ($rowname = mysqli_fetch_array($faqtitle, MYSQLI_ASSOC)){
					$showfaq=$showfaq. "<li>".$rowname['text']."</li>";
					faqproc($row['faqname'], 1);
				}
			}
		}
	}
}
$showfaq=$showfaq. "</div></td><td style=\"vertical-align: top\"><div style=\"overflow: auto; max-height: 720px;\"><iframe width=100% height=720px frameborder=0 id=\"faqanswer\" src=\"faq.php?faqname=welcomemessage\"></iframe></div></td></tr></table></div>";
echo $showfaq;
capcu_store("dsc_faqlist", $showfaq, 86400);
}
} else {
	$faqtoshow = $_GET['faqname'];
if ($showfaq = capcu_fetch("dsc_faq_item_".$faqtoshow)) {
	echo $showfaq;
} else {
	$showfaq="";
	$showfaq=$showfaq. "<title>F.A.Q.</title>";
	if ($faqtoshow == "welcomemessage") {
		$showfaq=$showfaq. "Select the question of interest to the left to view the answer to it";
	} else {
		$link = mysqli_connect("$host", "$username", "$password", "$db_name");
		if (!$link) {
			die('Connect Error (' . mysqli_connect_errno() . ') ' . mysqli_connect_error());
		} else {
			$faqtitle = mysqli_query($link, "SELECT text FROM ds__vb_phrase WHERE fieldname=\"faqtext\" And varname=\"".$faqtoshow."\"");
			if (mysqli_num_rows($faqtitle)) {
				while ($rowname = mysqli_fetch_array($faqtitle, MYSQLI_ASSOC)){
					$showfaq=$showfaq. $rowname['text']."<BR>";
				}
			}
		}
	}
echo $showfaq;
capcu_store("dsc_faq_item_".$faqtoshow, $showfaq, 86400);
}
}

?>