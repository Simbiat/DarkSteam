-- phpMyAdmin SQL Dump
-- version 4.0.10.14
-- http://www.phpmyadmin.net
--
-- Host: localhost:3306
-- Generation Time: Aug 31, 2016 at 03:07 AM
-- Server version: 5.5.50-cll
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `simbiatr_simbiat`
--
CREATE DATABASE IF NOT EXISTS `simbiatr_simbiat` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `simbiatr_simbiat`;

-- --------------------------------------------------------

--
-- Table structure for table `ds__dsgamelist`
--

CREATE TABLE IF NOT EXISTS `ds__dsgamelist` (
  `appID` int(20) NOT NULL DEFAULT '0',
  `Format` text COLLATE utf8_unicode_ci,
  `PathToACF` text COLLATE utf8_unicode_ci,
  `LastUpdated` text COLLATE utf8_unicode_ci,
  `UpdatedOn` int(11) NOT NULL DEFAULT '1356566220',
  `Addedon` int(11) NOT NULL DEFAULT '1356566220',
  `UpToDate` tinyint(1) NOT NULL DEFAULT '0',
  `GameName` text CHARACTER SET utf8,
  `CommonFolderSize` bigint(100) DEFAULT '0',
  `Language` text COLLATE utf8_unicode_ci,
  `ActiveDepots` longtext COLLATE utf8_unicode_ci,
  `RegUser` tinyint(1) NOT NULL DEFAULT '0',
  `GenAva` tinyint(1) NOT NULL DEFAULT '0',
  `exe1path` text COLLATE utf8_unicode_ci NOT NULL,
  `exe1desc` text COLLATE utf8_unicode_ci NOT NULL,
  `exe2path` text COLLATE utf8_unicode_ci NOT NULL,
  `exe2desc` text COLLATE utf8_unicode_ci NOT NULL,
  `exe3path` text COLLATE utf8_unicode_ci NOT NULL,
  `exe3desc` text COLLATE utf8_unicode_ci NOT NULL,
  `exe4path` text COLLATE utf8_unicode_ci NOT NULL,
  `exe4desc` text COLLATE utf8_unicode_ci NOT NULL,
  `exe5path` text COLLATE utf8_unicode_ci NOT NULL,
  `exe5desc` text COLLATE utf8_unicode_ci NOT NULL,
  `crack1path` text COLLATE utf8_unicode_ci NOT NULL,
  `crack1desc` text COLLATE utf8_unicode_ci NOT NULL,
  `crack2path` text COLLATE utf8_unicode_ci NOT NULL,
  `crack2desc` text COLLATE utf8_unicode_ci NOT NULL,
  `crack3path` text COLLATE utf8_unicode_ci NOT NULL,
  `crack3desc` text COLLATE utf8_unicode_ci NOT NULL,
  `crack4path` text COLLATE utf8_unicode_ci NOT NULL,
  `crack4desc` text COLLATE utf8_unicode_ci NOT NULL,
  `crack5path` text COLLATE utf8_unicode_ci NOT NULL,
  `crack5desc` text COLLATE utf8_unicode_ci NOT NULL,
  `addon1path` text COLLATE utf8_unicode_ci NOT NULL,
  `addon1desc` text COLLATE utf8_unicode_ci NOT NULL,
  `addon2path` text COLLATE utf8_unicode_ci NOT NULL,
  `addon2desc` text COLLATE utf8_unicode_ci NOT NULL,
  `addon3path` text COLLATE utf8_unicode_ci NOT NULL,
  `addon3desc` text COLLATE utf8_unicode_ci NOT NULL,
  `addon4path` text COLLATE utf8_unicode_ci NOT NULL,
  `addon4desc` text COLLATE utf8_unicode_ci NOT NULL,
  `addon5path` text COLLATE utf8_unicode_ci NOT NULL,
  `addon5desc` text COLLATE utf8_unicode_ci NOT NULL,
  `gamedesc` longtext COLLATE utf8_unicode_ci NOT NULL,
  `alldlcids` longtext COLLATE utf8_unicode_ci NOT NULL,
  `alldlcnames` longtext COLLATE utf8_unicode_ci NOT NULL,
  `gamefeatures` longtext COLLATE utf8_unicode_ci NOT NULL,
  `alldlcdesc` longtext COLLATE utf8_unicode_ci NOT NULL,
  `alldlcheads` longtext COLLATE utf8_unicode_ci NOT NULL,
  `reqage` text COLLATE utf8_unicode_ci NOT NULL,
  `headerimg` text COLLATE utf8_unicode_ci NOT NULL,
  `offwebsite` text COLLATE utf8_unicode_ci NOT NULL,
  `reqmin` longtext COLLATE utf8_unicode_ci NOT NULL,
  `reqrec` longtext COLLATE utf8_unicode_ci NOT NULL,
  `developers` longtext COLLATE utf8_unicode_ci NOT NULL,
  `publishers` longtext COLLATE utf8_unicode_ci NOT NULL,
  `genres` longtext COLLATE utf8_unicode_ci NOT NULL,
  `screenshots` longtext COLLATE utf8_unicode_ci NOT NULL,
  `releasedate` int(11) NOT NULL DEFAULT '0',
  `misstorr` tinyint(1) NOT NULL DEFAULT '1',
  `tirrinpr` tinyint(1) NOT NULL DEFAULT '0',
  `torrname` text COLLATE utf8_unicode_ci NOT NULL,
  `realpath` longtext COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci ROW_FORMAT=COMPRESSED;

-- --------------------------------------------------------

--
-- Table structure for table `ds__dspatchnotes`
--

CREATE TABLE IF NOT EXISTS `ds__dspatchnotes` (
  `id` int(11) NOT NULL,
  `version` text COLLATE utf8_unicode_ci NOT NULL,
  `notes` longtext COLLATE utf8_unicode_ci NOT NULL,
  `date` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ds__dsstaticvars`
--

CREATE TABLE IF NOT EXISTS `ds__dsstaticvars` (
  `id` int(10) NOT NULL,
  `name` text COLLATE utf8_unicode_ci NOT NULL,
  `parameter` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `ds__vb_cms_article`
--

CREATE TABLE IF NOT EXISTS `ds__vb_cms_article` (
  `contentid` int(10) unsigned NOT NULL,
  `pagetext` mediumtext NOT NULL,
  `threadid` int(10) unsigned DEFAULT NULL,
  `blogid` int(10) unsigned DEFAULT NULL,
  `posttitle` varchar(255) DEFAULT NULL,
  `postauthor` varchar(100) DEFAULT NULL,
  `poststarter` int(10) unsigned DEFAULT NULL,
  `blogpostid` int(10) unsigned DEFAULT NULL,
  `postid` int(10) unsigned DEFAULT NULL,
  `post_posted` int(10) unsigned DEFAULT NULL,
  `post_started` int(10) unsigned DEFAULT NULL,
  `previewtext` varchar(2048) DEFAULT NULL,
  `previewimage` varchar(256) DEFAULT NULL,
  `imagewidth` int(10) unsigned DEFAULT NULL,
  `imageheight` int(10) unsigned DEFAULT NULL,
  `previewvideo` text,
  `htmlstate` enum('off','on','on_nl2br') NOT NULL DEFAULT 'on_nl2br',
  `keepthread` smallint(5) unsigned NOT NULL DEFAULT '0',
  `allcomments` smallint(5) unsigned NOT NULL DEFAULT '0',
  `movethread` smallint(5) unsigned NOT NULL DEFAULT '1'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPRESSED;

-- --------------------------------------------------------

--
-- Table structure for table `ds__vb_cms_node`
--

CREATE TABLE IF NOT EXISTS `ds__vb_cms_node` (
  `nodeid` int(10) unsigned NOT NULL,
  `nodeleft` int(10) unsigned NOT NULL,
  `noderight` int(10) unsigned NOT NULL,
  `parentnode` int(10) unsigned DEFAULT NULL,
  `contenttypeid` int(10) unsigned NOT NULL,
  `contentid` int(10) unsigned DEFAULT '0',
  `url` text,
  `styleid` int(10) unsigned DEFAULT NULL,
  `layoutid` int(10) unsigned DEFAULT NULL,
  `userid` int(10) unsigned NOT NULL DEFAULT '0',
  `publishdate` int(10) unsigned DEFAULT NULL,
  `setpublish` tinyint(3) unsigned DEFAULT '0',
  `issection` tinyint(4) DEFAULT '0',
  `onhomepage` tinyint(4) DEFAULT '0',
  `permissionsfrom` int(10) unsigned DEFAULT '0',
  `lastupdated` int(10) unsigned DEFAULT NULL,
  `publicpreview` tinyint(4) DEFAULT '0',
  `auto_displayorder` tinyint(4) DEFAULT '0',
  `comments_enabled` tinyint(4) DEFAULT '0',
  `new` tinyint(3) unsigned NOT NULL DEFAULT '0',
  `showtitle` smallint(6) DEFAULT '1',
  `showuser` smallint(6) DEFAULT '1',
  `showpreviewonly` smallint(6) DEFAULT '1',
  `showupdated` smallint(6) DEFAULT '0',
  `showviewcount` smallint(6) DEFAULT '0',
  `showpublishdate` smallint(6) DEFAULT '1',
  `settingsforboth` smallint(6) DEFAULT '1',
  `includechildren` smallint(6) DEFAULT '1',
  `showall` smallint(6) DEFAULT '1',
  `editshowchildren` smallint(6) DEFAULT '1',
  `showrating` smallint(6) DEFAULT '0',
  `hidden` smallint(6) DEFAULT '0',
  `shownav` smallint(6) DEFAULT '0',
  `nosearch` smallint(6) DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPRESSED;

-- --------------------------------------------------------

--
-- Table structure for table `ds__vb_cms_nodeinfo`
--

CREATE TABLE IF NOT EXISTS `ds__vb_cms_nodeinfo` (
  `nodeid` int(10) unsigned NOT NULL,
  `description` mediumtext,
  `title` text,
  `html_title` text,
  `viewcount` int(10) unsigned DEFAULT '0',
  `creationdate` int(10) unsigned NOT NULL,
  `workflowdate` int(10) unsigned DEFAULT NULL,
  `workflowstatus` enum('draft','parentpending','published','deleted') DEFAULT NULL,
  `workflowcheckedout` tinyint(4) DEFAULT NULL,
  `workflowpending` tinyint(4) DEFAULT NULL,
  `workflowlevelid` int(10) unsigned DEFAULT '0',
  `associatedthreadid` int(10) unsigned NOT NULL DEFAULT '0',
  `keywords` text,
  `ratingnum` int(10) unsigned NOT NULL DEFAULT '0',
  `ratingtotal` int(10) unsigned NOT NULL DEFAULT '0',
  `rating` float unsigned NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPRESSED;

-- --------------------------------------------------------

--
-- Table structure for table `ds__vb_faq`
--

CREATE TABLE IF NOT EXISTS `ds__vb_faq` (
  `faqname` varchar(250) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `faqparent` varchar(50) NOT NULL DEFAULT '',
  `displayorder` smallint(5) unsigned NOT NULL DEFAULT '0',
  `volatile` smallint(5) unsigned NOT NULL DEFAULT '0',
  `product` varchar(25) NOT NULL DEFAULT ''
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPRESSED;

-- --------------------------------------------------------

--
-- Table structure for table `ds__vb_phrase`
--

CREATE TABLE IF NOT EXISTS `ds__vb_phrase` (
  `phraseid` int(10) unsigned NOT NULL,
  `languageid` smallint(6) NOT NULL DEFAULT '0',
  `varname` varchar(250) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL DEFAULT '',
  `fieldname` varchar(20) NOT NULL DEFAULT '',
  `text` mediumtext,
  `product` varchar(25) NOT NULL DEFAULT '',
  `username` varchar(100) NOT NULL DEFAULT '',
  `dateline` int(10) unsigned NOT NULL DEFAULT '0',
  `version` varchar(30) NOT NULL DEFAULT '',
  `importphraseid` bigint(20) NOT NULL DEFAULT '0'
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPRESSED;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
