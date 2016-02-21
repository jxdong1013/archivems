/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50624
Source Host           : 127.0.0.1:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2016-02-21 20:58:34
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_archive
-- ----------------------------
DROP TABLE IF EXISTS `t_archive`;
CREATE TABLE `t_archive` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `idx` varchar(50) DEFAULT NULL,
  `manager` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `pages` varchar(255) DEFAULT NULL,
  `number` varchar(100) DEFAULT NULL,
  `remark` varchar(255) DEFAULT NULL,
  `operateman` varchar(255) NOT NULL,
  `operatetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `boxid` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=112 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_archive
-- ----------------------------

-- ----------------------------
-- Table structure for t_boxlabel
-- ----------------------------
DROP TABLE IF EXISTS `t_boxlabel`;
CREATE TABLE `t_boxlabel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `rfid` varchar(100) NOT NULL,
  `number` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_boxlabel
-- ----------------------------

-- ----------------------------
-- Table structure for t_floorlabel
-- ----------------------------
DROP TABLE IF EXISTS `t_floorlabel`;
CREATE TABLE `t_floorlabel` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `rfid` varchar(255) NOT NULL,
  `number` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_floorlabel
-- ----------------------------

-- ----------------------------
-- Table structure for t_inventory
-- ----------------------------
DROP TABLE IF EXISTS `t_inventory`;
CREATE TABLE `t_inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL,
  `operateid` int(11) NOT NULL,
  `operatename` varchar(50) NOT NULL,
  `operatetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_inventory
-- ----------------------------

-- ----------------------------
-- Table structure for t_inventorydetail
-- ----------------------------
DROP TABLE IF EXISTS `t_inventorydetail`;
CREATE TABLE `t_inventorydetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mid` int(11) NOT NULL,
  `floorrfid` varchar(100) NOT NULL,
  `boxrfid` varchar(100) DEFAULT NULL,
  `status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_inventorydetail
-- ----------------------------

-- ----------------------------
-- Table structure for t_position
-- ----------------------------
DROP TABLE IF EXISTS `t_position`;
CREATE TABLE `t_position` (
  `boxrfid` varchar(50) NOT NULL,
  `floorrfid` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_position
-- ----------------------------

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `userid` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(45) NOT NULL,
  `password` varchar(45) NOT NULL,
  `realname` varchar(45) DEFAULT NULL,
  `sex` varchar(45) DEFAULT '男',
  `phone` varchar(45) DEFAULT NULL,
  `age` int(2) DEFAULT '30',
  `roletype` varchar(45) DEFAULT NULL,
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `createman` varchar(45) NOT NULL,
  `modifytime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `modifyman` varchar(45) NOT NULL,
  `enable` smallint(2) NOT NULL DEFAULT '1',
  `address` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'admin', '123456', 'admin', '女', '137571934761111', '30', null, '2016-01-16 13:16:31', 'admin', '2016-02-21 13:36:46', 'admin11', '1', null);

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost`  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark,
 b.name as boxname , c.boxrfid , d.name as floorname , c.floorrfid  , CONCAT (d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ;

-- ----------------------------
-- View structure for v_box
-- ----------------------------
DROP VIEW IF EXISTS `v_box`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_box` AS select a.id , a.name,a.number , a.rfid , b.floorrfid , c.name as floorname from t_boxlabel a LEFT JOIN t_position b on a.rfid= b.boxrfid LEFT JOIN t_floorlabel c on b.floorrfid= c.rfid ;
