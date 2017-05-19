/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-05-19 10:06:51
*/

SET FOREIGN_KEY_CHECKS=0;

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
