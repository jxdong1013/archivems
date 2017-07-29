/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50624
Source Host           : 127.0.0.1:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2017-05-21 15:38:22
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
  `status` int(11) DEFAULT '0' COMMENT '0:在库，1：借出',
  `borrowid` int(11) DEFAULT '0',
  `lastborrowtime` datetime DEFAULT NULL COMMENT '最近借阅时间或者归还时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2200 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_borrow
-- ----------------------------
DROP TABLE IF EXISTS `t_borrow`;
CREATE TABLE `t_borrow` (
  `borrowid` bigint(20) NOT NULL AUTO_INCREMENT,
  `archiveid` int(20) DEFAULT NULL COMMENT '档案id',
  `borrowerid` int(11) DEFAULT NULL COMMENT '借阅人id',
  `status` int(11) DEFAULT '0' COMMENT '0：在库1：借出',
  `createtime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP,
  `operatorid` int(11) DEFAULT NULL COMMENT '经办人id',
  `operatorname` varchar(255) DEFAULT NULL COMMENT '经办人',
  `remark` varchar(256) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`borrowid`)
) ENGINE=InnoDB AUTO_INCREMENT=131 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_borrower
-- ----------------------------
DROP TABLE IF EXISTS `t_borrower`;
CREATE TABLE `t_borrower` (
  `borrowerid` int(20) NOT NULL AUTO_INCREMENT,
  `idcard` varchar(20) DEFAULT NULL COMMENT '身份证',
  `no` varchar(255) DEFAULT NULL COMMENT '员工编号',
  `name` varchar(100) NOT NULL COMMENT '姓名',
  `department` varchar(100) DEFAULT NULL COMMENT '部门',
  `phone` varchar(100) DEFAULT NULL COMMENT '手机',
  `address` varchar(256) DEFAULT NULL COMMENT '地址',
  `sex` varchar(10) DEFAULT '男' COMMENT '性别',
  `post` varchar(50) DEFAULT NULL COMMENT '职位',
  `remark` varchar(256) DEFAULT NULL,
  `createtime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`borrowerid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

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
  `borrowstatus` varchar(50) DEFAULT NULL,
  `borrowdate` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for t_position
-- ----------------------------
DROP TABLE IF EXISTS `t_position`;
CREATE TABLE `t_position` (
  `boxrfid` varchar(50) NOT NULL,
  `floorrfid` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark, a.status , (case a.status when 0 then '在库' when 1 then '借出' else '未知֪' end) as statusname,
 b.name as boxname , b.rfid as boxrfid , b.number as boxnumber , d.name as floorname , c.floorrfid  , CONCAT_WS(',', d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ; ;

-- ----------------------------
-- View structure for v_borrow
-- ----------------------------
DROP VIEW IF EXISTS `v_borrow`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_borrow` AS select a.id , a.title,a.number, a.manager , a.idx , a.pages, a.status, (case a.status when 0 then '在库' when 1 then '借出' else '未知֪' end) as statusname,
b.id as boxid , b.name as boxname , b.number as boxnumber,b.rfid as boxrfid ,
CONCAT_WS(',', d.name , b.name) as position ,
d.number as floornumber , d.name as floorname,d.rfid as floorrfid,
e.createtime , e.operatorname ,
f.borrowerid , f.name as borrowername,f.idcard , f.department
from t_archive a
left join t_boxlabel b 
on a.boxid= b.id
left join t_position c
on b.rfid=c.boxrfid
left join t_floorlabel d
on c.floorrfid= d.rfid
left join t_borrow e
on a.borrowid=e.borrowid
left join t_borrower f
on e.borrowerid = f.borrowerid ; ;

-- ----------------------------
-- View structure for v_box
-- ----------------------------
DROP VIEW IF EXISTS `v_box`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_box` AS select a.id , a.name,a.number , a.rfid , b.floorrfid , c.name as floorname from t_boxlabel a LEFT JOIN t_position b on a.rfid= b.boxrfid LEFT JOIN t_floorlabel c on b.floorrfid= c.rfid ;
