/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50624
Source Host           : 127.0.0.1:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50624
File Encoding         : 65001

Date: 2016-02-23 21:13:47
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
) ENGINE=InnoDB AUTO_INCREMENT=46 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_archive
-- ----------------------------
INSERT INTO `t_archive` VALUES ('1', '1', '扬州市申遗办', '淮扬运河扬州段遗产介绍', '4', '3210000101010010120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('2', '2', '扬州市申遗办', '古邗沟故道（邗沟东道）遗产介绍', '1', '3210230101010020120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('3', '3', '扬州市申遗办', '高邮明清大运河故道遗产介绍', '2', '3210840101010030120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('4', '4', '扬州市申遗办', '邵伯明清大运河故道遗产介绍', '1', '3210120101010040120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('5', '5', '扬州市申遗办', '扬州古运河遗产介绍', '1', '3210000101010050120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('6', '6', '扬州市申遗办', '瓜洲运河遗产介绍', '1', '3210030101010060120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('7', '7', '扬州市申遗办', '刘堡减水闸遗产介绍', '5', '3210230102010010320130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('8', '8', '扬州市申遗办', '盂城驿遗产介绍', '2', '3210840103010010120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('9', '9', '扬州市申遗办', '邵伯古堤遗产介绍', '1', '3210120104010010120130530', ' ', 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('10', '10', '扬州市申遗办', '邵伯码头遗产介绍', '1', '3210120105010010120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('11', '11', '扬州市申遗办', '瘦西湖遗产介绍', '6', '3210000106010010120130530', null, 'admin', '2016-02-23 20:58:00', '0');
INSERT INTO `t_archive` VALUES ('12', '12', '扬州市申遗办', '瘦西湖风景区概况', '33', '3210000106010020120130530', null, 'admin', '2016-02-23 20:58:00', '1');
INSERT INTO `t_archive` VALUES ('13', '13', '扬州博物馆', '《广陵名胜全图》节选', '31', '3210000106010030120130530', null, 'admin', '2016-02-23 20:58:00', '1');
INSERT INTO `t_archive` VALUES ('14', '14', '扬州市申遗办', '扬州历史城壕（保障河）文化景观主要遗存点简介', '24', '3210000106010040120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('15', '15', '扬州市申遗办', '天宁寺遗产介绍', '2', '3210030107010010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('16', '16', '扬州市申遗办', '重宁寺遗产介绍', '1', '3210030107010020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('17', '17', '扬州市申遗办', '盐业历史遗迹—个园遗产介绍', '5', '3210020108010010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('18', '18', '扬州市申遗办', '个园概况', '10', '3210020108010020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('19', '19', '刘凤诰', '个园记', '1', '3210020108010030120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('20', '20', '扬州市申遗办', '个园楹联全编', '6', '3210020108010040120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('21', '21', '扬州市申遗办', '盐业历史遗迹—汪鲁门遗产介绍', '1', '3210020109010010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('22', '22', '扬州市申遗办', '世德堂：盐商汪鲁门住宅', '5', '3210020109010020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('23', '23', '扬州市申遗办', '盐业历史遗迹—盐宗庙遗产介绍', '1', '3210020110010010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('24', '24', '扬州市申遗办', '盐业历史遗迹—卢绍绪盐商住宅遗产介绍', '1', '3210020111010010120130530', ' ', 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('25', '25', '扬州市申遗办', '淮扬运河扬州段历史沿革', '8', '3210000101020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('26', '26', '扬州市申遗办', '古邗沟故道（邗沟东道）历史沿革', '1', '3210230101020020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('27', '27', '扬州市申遗办', '高邮明清大运河故道历史沿革', '1', '3210840101020030120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('28', '28', '扬州市申遗办', '邵伯明清大运河故道历史沿革', '1', '3210120101020040120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('29', '29', '扬州市申遗办', '扬州古运河历史沿革', '1', '3210000101020050120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('30', '30', '扬州市申遗办', '瓜洲运河历史沿革', '1', '3210030101020060120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('31', '31', '扬州市申遗办', '刘堡减水闸历史沿革', '1', '3210230102020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('32', '32', '扬州市申遗办', '盂城驿历史沿革', '1', '3210840103020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('33', '33', '扬州市申遗办', '邵伯古堤历史沿革', '1', '3210120104020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('34', '34', '扬州市申遗办', '邵伯码头遗产历史沿革', '1', '3210120105020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('35', '35', '扬州市申遗办', '瘦西湖历史沿革', '3', '3010000106020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('36', '36', '扬州市申遗办', '天宁寺历史沿革', '1', '3210030107020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('37', '37', '扬州市申遗办', '重宁寺历史沿革', '1', '3210030107020020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('38', '38', '扬州市申遗办', '个园历史沿革(1)', '1', '3210020108020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('39', '39', '扬州市申遗办', '个园历史沿革(2)', '6', '3210020108020020120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('40', '40', '扬州市申遗办', '汪鲁门历史沿革', '1', '3210020109020010120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('41', '41', '江苏财政厅', '汪鲁门民国八年房契', '2', '3210020109020020120130530', '民国八年', 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('42', '42', '扬州市申遗办', '汪鲁门平面示意图', '1', '3210020109020030120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('43', '43', '扬州市申遗办', '汪鲁门平面图', '7', '3210020109020040120130530', '39083', 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('44', '44', '汪明', '缅怀嗣祖父——汪鲁门', '5', '3210020109020050120130530', null, 'admin', '2016-02-23 20:58:01', '1');
INSERT INTO `t_archive` VALUES ('45', '45', '葛星明', '世德堂：盐商汪鲁门住宅', '2', '3210020109020060120130530', null, 'admin', '2016-02-23 20:58:01', '1');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_boxlabel
-- ----------------------------
INSERT INTO `t_boxlabel` VALUES ('1', '11', '11111', '11');

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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_floorlabel
-- ----------------------------
INSERT INTO `t_floorlabel` VALUES ('1', '2432423', '23423423', '23423');

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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
INSERT INTO `t_position` VALUES ('11111', '23423423');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'admin', '123456', 'admin', '女', '137571934761111', '30', 'admin', '2016-01-16 13:16:31', 'admin', '2016-02-21 13:36:46', 'admin11', '1', null);
INSERT INTO `t_user` VALUES ('2', 'jxd', '123456', 'jxd', '女', '双方萨芬', '30', 'user', '2016-02-23 20:57:25', 'admin', '2016-02-23 21:02:58', 'admin', '1', null);

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark,
 b.name as boxname , b.rfid as boxrfid , d.name as floorname , c.floorrfid  , CONCAT_WS(',', d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ;

-- ----------------------------
-- View structure for v_box
-- ----------------------------
DROP VIEW IF EXISTS `v_box`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_box` AS select a.id , a.name,a.number , a.rfid , b.floorrfid , c.name as floorname from t_boxlabel a LEFT JOIN t_position b on a.rfid= b.boxrfid LEFT JOIN t_floorlabel c on b.floorrfid= c.rfid ;
