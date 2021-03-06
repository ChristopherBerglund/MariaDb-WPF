using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariaDb_WPF
{
    public class Global
    {
        public static string myEmail;
        public static string myEmailPassword;
        public static string ConnectionString;
        public static string secretKey = "secretkey";
        public static string CreateDB = @"-- --------------------------------------------------------
-- Värd:                         127.0.0.1
-- Serverversion:                10.6.5-MariaDB - mariadb.org binary distribution
-- Server-OS:                    Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumpar databasstruktur för gnu
CREATE DATABASE IF NOT EXISTS `gnu` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `gnu`;

-- Dumpar struktur för tabell gnu.comments
CREATE TABLE IF NOT EXISTS `comments` (
  `commentid` int(11) NOT NULL,
  `user` varchar(50) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `comment_text` varchar(100) NOT NULL,
  `postid` int(11) NOT NULL,
  PRIMARY KEY (`commentid`) USING BTREE,
  KEY `FK_comments_posts` (`postid`),
  CONSTRAINT `FK_comments_posts` FOREIGN KEY (`postid`) REFERENCES `posts` (`postid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumpar data för tabell gnu.comments: ~0 rows (ungefär)
/*!40000 ALTER TABLE `comments` DISABLE KEYS */;
/*!40000 ALTER TABLE `comments` ENABLE KEYS */;

-- Dumpar struktur för tabell gnu.discussion
CREATE TABLE IF NOT EXISTS `discussion` (
  `discussionid` int(11) NOT NULL,
  `headline` varchar(50) DEFAULT NULL,
  `discussiontext` varchar(500) DEFAULT NULL,
  `user` varchar(50) DEFAULT NULL,
  `createddate` datetime DEFAULT NULL,
  PRIMARY KEY (`discussionid`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumpar data för tabell gnu.discussion: ~0 rows (ungefär)
/*!40000 ALTER TABLE `discussion` DISABLE KEYS */;
/*!40000 ALTER TABLE `discussion` ENABLE KEYS */;

-- Dumpar struktur för tabell gnu.posts
CREATE TABLE IF NOT EXISTS `posts` (
  `postid` int(11) NOT NULL,
  `User` varchar(50) NOT NULL DEFAULT '',
  `text` varchar(1000) NOT NULL DEFAULT '',
  `DateTime` datetime NOT NULL,
  `discussionid` int(11) NOT NULL,
  PRIMARY KEY (`postid`) USING BTREE,
  KEY `FK_posts_discussion` (`discussionid`),
  CONSTRAINT `FK_posts_discussion` FOREIGN KEY (`discussionid`) REFERENCES `discussion` (`discussionid`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumpar data för tabell gnu.posts: ~0 rows (ungefär)
/*!40000 ALTER TABLE `posts` DISABLE KEYS */;
/*!40000 ALTER TABLE `posts` ENABLE KEYS */;

-- Dumpar struktur för tabell gnu.timesetter
CREATE TABLE IF NOT EXISTS `timesetter` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `TimeSet` datetime NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=latin1;

-- Dumpar data för tabell gnu.timesetter: ~0 rows (ungefär)
/*!40000 ALTER TABLE `timesetter` DISABLE KEYS */;
INSERT INTO `timesetter` (`ID`, `TimeSet`) VALUES
	(1, '1950-01-01 00:00:00');
/*!40000 ALTER TABLE `timesetter` ENABLE KEYS */;

-- Dumpar struktur för tabell gnu.users
CREATE TABLE IF NOT EXISTS `users` (
  `userid` int(11) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`userid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- Dumpar data för tabell gnu.users: ~3 rows (ungefär)
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` (`userid`, `username`, `email`) VALUES
	(1, 'bober', 'bobertestar@gmail.com'),
	(2, 'Sam', 'mintestmail321@gmail.com'),
	(3, 'Alb', 'albincodetesting@gmail.com'),
	(4, 'Love', 'developertestingcrash@gmail.com'),
	(5, 'Yos', 'mailconsolejonatan@gmail.com');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
";
    
    }
}
