/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-05-19 10:05:38
*/

SET FOREIGN_KEY_CHECKS=0;

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
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8;
