<?php
if ($showcss = capcu_fetch("dsc_css")) {
	echo $showcss;
} else {
	$showcss="";
$showcss=$showcss. "<style>

body{
color: whitesmoke;
font-family:Microsoft Sans Serif;
font-size:10pt;
background:#292a2b none ;
}

.forumblock{
background-color: transparent;
}

table, th, td, tr{
color: whitesmoke;
font-family:Microsoft Sans Serif;
font-size:10pt;
}

a:link {text-decoration:none;}
a:link {color:#74BBFB;}
a:visited {color:#74BBFB;}
a:hover {color:#74BBFB;}
a:active {color:#74BBFB;}


.back-to-top {
position: fixed;
border-radius: 15px;
bottom: 1pt;
right: 0px;
text-decoration: none;
color: #000000;
background-color: rgba(151, 151, 151, 0.80);
font-size: 12px;
padding: 2pt;
display: none;
}

.back-to-top:hover {    
    background-color: rgba(151, 151, 151, 0.50);
}

ul {
list-style: none;
padding: 0;
}
</style>";
echo $showcss;
capcu_store("dsc_css", $showcss, 86400);
}
?>