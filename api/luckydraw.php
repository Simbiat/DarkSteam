<?php
ini_set( "display_errors", 0);
$curdir = getcwd ();
require_once "../../genfunc/config.php";
chdir ($curdir);

	$forumpath = "http://a12.net.ru/";

	Echo "
		<title>DarkSteam - Lucky Draw</title>";
echo "
<script>
    // Attach a submit handler to the form
    $( \"#draw\" ).submit(function( event ) {

        // Stop form from submitting normally
        event.preventDefault();

        // Get some values from elements on the page:
        var $form = $( this ),
            partis = $form.find( \"input[name='parti']\" ).val(),
            lifetis = $form.find( \"input[name='lifeti']\" ).val(),
            giftis = $form.find( \"input[name='gifti']\" ).val(),
            url = $form.attr( \"action\" );

        // Send the data using post
        var posting = $.post( url, { parti: partis } );

        // Put the results in a div
        posting.done(function( data ) {
            var content = $( data ).find( \"#content\" );
            $( \"#result\" ).empty().append( content );
        });
    });
</script>
";
require_once('./css.php');
//if ($vbulletin->userinfo['userid'] == '1' ){
echo "
	<div id=\"content\"><center><form id=\"draw\" action=\"luckydraw.php\" method=\"post\">
	<table>
		<tr>
			<td>
				<center>Regulars<a href=\"#\"><sup style=\"font-size:xx-small; vertical-align:super;\" title=\"List of regular users with no special priviliges\">[?]</sup></a><br>
				<textarea id=\"parti\" name=\"parti\" cols=\"15\" rows=\"20\" style=\"color:lightblue; font-weight:bold\">".$_POST[parti]."</textarea></center>
			</td>
			<td>
				<center>Specials<a href=\"#\"><sup style=\"font-size:xx-small; vertical-align:super;\" title=\"List of users with some special priviliges, e.g. subscribers. Optional\">[?]</sup></a><br>
				<textarea id=\"lifeti\" name=\"lifeti\" cols=\"15\" rows=\"20\" style=\"color:lightblue; font-weight:bold\">".$_POST[lifeti]."</textarea></center>
			</td>
			<td>
				<center>Gifts<a href=\"#\"><sup style=\"font-size:xx-small; vertical-align:super;\" title=\"List of giveaways *BESIDES* subscription\">[?]</sup></a><br>
				<textarea id=\"gifti\" name=\"gifti\" cols=\"15\" rows=\"20\" style=\"color:lightblue; font-weight:bold\">".$_POST[gifti]."</textarea></center>
			</td>
		</tr>
		<tr>
			<td>
			</td>
			<td>
				<center><br><br><div id=\"submit_div\"><input id=\"submit\" name=\"submit\" type=\"submit\" value=\"Roll the dice!\"></div><br><br><div id=\"result\"></div></center>
			</td>
			<td>
			</td>
		</tr>
	</table>
	</form></center></div>
";

echo "
	<center><table><tr><td></td><td><center>
";

if (!is_null($_POST[parti]) and !is_null($_POST[gifti])) {
$parti = explode("\n", $_POST[parti]);
$lifeti = explode("\n", $_POST[lifeti]);
$gifti = explode("\n", $_POST[gifti]);
shuffle($gifti);
shuffle($gifti);
shuffle($gifti);


$elifeti = array_filter($lifeti);
if (!empty($elifeti)) {
	$allpart = array_merge($parti, $lifeti);
} else {
	$allpart = array_merge($parti);
}
shuffle($allpart);
shuffle($allpart);
shuffle($allpart);

$winner1=0;
$winner2=0;
$winner3=0;
$numberofgames=0;
$gametolife=0;

while ($winner1==0 or $winner2==0) {
	$eallpart = array_filter($allpart);
	if (!empty($eallpart)) {
		$winner = array_rand($allpart, 1);
		if ($winner and !in_array($allpart[$winner], $lifeti) and $winner1==0) {
			$winner1=1;
			echo "<font color=lightgreen><b>".$allpart[$winner]."</b></font> wins <font color=gold><b>lifetime subscription</b></font><br>";
			unset($allpart[$winner]);
			$allpart = array_values($allpart);
			shuffle($allpart);
			shuffle($allpart);
			shuffle($allpart);
			if ($winner2==1) {
				$winner3=1;
			}
		} else {
			if ($winner3==0) {
				$winner2=1;
				$egifti = array_filter($gifti);
				if (!empty($egifti)) {
					$gamegift = array_rand($gifti, 1);
					echo "<font color=lightgreen><b>".$allpart[$winner]."</b></font> wins <font color=bronze><b>".$gifti[$gamegift]."</b></font><br>";
					$numberofgames=++$numberofgames;
					if (in_array($allpart[$winner], $lifeti)) {
						$gametolife=1;
					}
					unset($allpart[$winner]);
					$allpart = array_values($allpart);
					shuffle($allpart);
					shuffle($allpart);
					shuffle($allpart);
					unset($gifti[$gamegift]);
					$gifti = array_values($gifti);
					shuffle($allpart);
					shuffle($allpart);
					shuffle($allpart);
				}
			}
		}
	}
}
if ($gametolife==1 and $numberofgames==1) {
	echo "<font color=lightgreen><b>".$parti[$winner]."</b></font> wins <font color=bronze><b>".$gifti[$gamegift]."</b></font><br>";
}
}

echo "
	</center></td><td></td></tr></table></center>
";
//} else {
//	echo "<center>This page is for administrator only</center>";
//}
?>