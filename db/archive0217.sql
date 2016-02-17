/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2016-02-17 20:34:12
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
  `floorid` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=67 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_archive
-- ----------------------------
INSERT INTO `t_archive` VALUES ('22', '1', '扬州市申遗办', '淮扬运河扬州段遗产介绍', '4', '3210000101010010120130530', null, 'admin', '2016-01-16 22:22:57', '23', '0');
INSERT INTO `t_archive` VALUES ('23', '2', '扬州市申遗办', '古邗沟故道（邗沟东道）遗产介绍', '1', '3210230101010020120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('24', '3', '扬州市申遗办', '高邮明清大运河故道遗产介绍', '2', '3210840101010030120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('25', '4', '扬州市申遗办', '邵伯明清大运河故道遗产介绍', '1', '3210120101010040120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('26', '5', '扬州市申遗办', '扬州古运河遗产介绍', '1', '3210000101010050120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('27', '6', '扬州市申遗办', '瓜洲运河遗产介绍', '1', '3210030101010060120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('28', '7', '扬州市申遗办', '刘堡减水闸遗产介绍', '5', '3210230102010010320130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('29', '8', '扬州市申遗办', '盂城驿遗产介绍', '2', '3210840103010010120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('30', '9', '扬州市申遗办', '邵伯古堤遗产介绍', '1', '3210120104010010120130530', ' ', 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('31', '10', '扬州市申遗办', '邵伯码头遗产介绍', '1', '3210120105010010120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('32', '11', '扬州市申遗办', '瘦西湖遗产介绍', '6', '3210000106010010120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('33', '12', '扬州市申遗办', '瘦西湖风景区概况', '33', '3210000106010020120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('34', '13', '扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆', '《广陵名胜全图》节选', '31', '3210000106010030120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('35', '14', '扬州市申遗办', '扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介', '24', '3210000106010040120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('36', '15', '扬州市申遗办', '天宁寺遗产介绍', '2', '3210030107010010120130530', null, 'admin', '2016-01-16 22:22:57', '15', '0');
INSERT INTO `t_archive` VALUES ('37', '16', '扬州市申遗办', '重宁寺遗产介绍', '1', '3210030107010020120130530', null, 'admin', '2016-01-16 22:22:57', '19', '0');
INSERT INTO `t_archive` VALUES ('38', '17', '扬州市申遗办', '盐业历史遗迹—个园遗产介绍', '5', '3210020108010010120130530', null, 'admin', '2016-01-16 22:22:57', '19', '0');
INSERT INTO `t_archive` VALUES ('39', '18', '扬州市申遗办', '个园概况', '10', '3210020108010020120130530', null, 'admin', '2016-01-16 22:22:57', '19', '0');
INSERT INTO `t_archive` VALUES ('40', '19', '刘凤诰', '个园记', '1', '3210020108010030120130530', null, 'admin', '2016-01-16 22:22:57', '19', '0');
INSERT INTO `t_archive` VALUES ('41', '20', '扬州市申遗办', '个园楹联全编', '6', '3210020108010040120130530', null, 'admin', '2016-01-17 10:26:18', '15', '0');
INSERT INTO `t_archive` VALUES ('42', '21', '扬州市申遗办', '盐业历史遗迹—汪鲁门遗产介绍', '1', '3210020109010010120130530', null, 'admin', '2016-01-17 10:26:19', '15', '0');
INSERT INTO `t_archive` VALUES ('43', '22', '扬州市申遗办', '世德堂：盐商汪鲁门住宅', '5', '3210020109010020120130530', null, 'admin', '2016-01-17 10:26:19', '15', '0');
INSERT INTO `t_archive` VALUES ('44', '23', '扬州市申遗办', '盐业历史遗迹—盐宗庙遗产介绍', '1', '3210020110010010120130530', null, 'admin', '2016-01-17 10:26:19', '15', '0');
INSERT INTO `t_archive` VALUES ('45', '24', '扬州市申遗办', '盐业历史遗迹—卢绍绪盐商住宅遗产介绍', '1', '3210020111010010120130530', ' ', 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('46', '25', '扬州市申遗办', '淮扬运河扬州段历史沿革', '8', '3210000101020010120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('47', '26', '扬州市申遗办', '古邗沟故道（邗沟东道）历史沿革', '1', '3210230101020020120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('48', '27', '扬州市申遗办', '高邮明清大运河故道历史沿革', '1', '3210840101020030120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('49', '28', '扬州市申遗办', '邵伯明清大运河故道历史沿革', '1', '3210120101020040120130530', null, 'admin', '2016-01-17 10:26:19', '19', '0');
INSERT INTO `t_archive` VALUES ('50', '29', '扬州市申遗办', '扬州古运河历史沿革', '1', '3210000101020050120130530', null, 'admin', '2016-01-17 10:26:19', '19', '0');
INSERT INTO `t_archive` VALUES ('51', '30', '扬州市申遗办', '瓜洲运河历史沿革', '1', '3210030101020060120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('52', '31', '扬州市申遗办', '刘堡减水闸历史沿革', '1', '3210230102020010120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('53', '32', '扬州市申遗办', '盂城驿历史沿革', '1', '3210840103020010120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('54', '33', '扬州市申遗办', '邵伯古堤历史沿革', '1', '3210120104020010120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('55', '34', '扬州市申遗办', '邵伯码头遗产历史沿革', '1', '3210120105020010120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('56', '35', '扬州市申遗办', '瘦西湖历史沿革', '3', '3010000106020010120130530', null, 'admin', '2016-01-17 10:26:19', '17', '0');
INSERT INTO `t_archive` VALUES ('57', '36', '扬州市申遗办', '天宁寺历史沿革', '1', '3210030107020010120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('58', '37', '扬州市申遗办', '重宁寺历史沿革', '1', '3210030107020020120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('59', '38', '扬州市申遗办', '个园历史沿革(1)', '1', '3210020108020010120130530', null, 'admin', '2016-01-17 10:26:19', '9', '0');
INSERT INTO `t_archive` VALUES ('60', '39', '扬州市申遗办', '个园历史沿革(2)', '6', '3210020108020020120130530', null, 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('61', '40', '扬州市申遗办', '汪鲁门历史沿革', '1', '3210020109020010120130530', null, 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('62', '41', '江苏财政厅', '汪鲁门民国八年房契', '2', '3210020109020020120130530', '民国八年', 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('63', '42', '扬州市申遗办', '汪鲁门平面示意图', '1', '3210020109020030120130530', null, 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('64', '43', '扬州市申遗办', '汪鲁门平面图', '7', '3210020109020040120130530', '39083', 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('65', '44', '汪明', '缅怀嗣祖父——汪鲁门', '5', '3210020109020050120130530', null, 'admin', '2016-01-17 10:26:19', '8', '0');
INSERT INTO `t_archive` VALUES ('66', '45', '葛星明', '世德堂：盐商汪鲁门住宅', '2', '3210020109020060120130530', null, 'admin', '2016-01-17 10:26:19', '8', '0');

-- ----------------------------
-- Table structure for t_boxlabel
-- ----------------------------
DROP TABLE IF EXISTS `t_boxlabel`;
CREATE TABLE `t_boxlabel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL,
  `rfid` varchar(100) NOT NULL,
  `number` varchar(100) DEFAULT NULL,
  `floorid` int(11) DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_boxlabel
-- ----------------------------
INSERT INTO `t_boxlabel` VALUES ('8', 'box213档案盒档案盒档案盒档案盒', '213', null, '0');
INSERT INTO `t_boxlabel` VALUES ('9', 'box214', '214', null, '0');
INSERT INTO `t_boxlabel` VALUES ('10', 'box215', '215', null, '0');
INSERT INTO `t_boxlabel` VALUES ('11', 'box216', '216', null, '0');
INSERT INTO `t_boxlabel` VALUES ('12', 'box217', '217', null, '0');
INSERT INTO `t_boxlabel` VALUES ('13', 'box218', '218', null, '0');
INSERT INTO `t_boxlabel` VALUES ('14', 'box219', '219', null, '0');
INSERT INTO `t_boxlabel` VALUES ('15', 'box300', '300', null, '0');
INSERT INTO `t_boxlabel` VALUES ('16', 'box301', '301', null, '0');
INSERT INTO `t_boxlabel` VALUES ('17', 'box302', '302', null, '0');
INSERT INTO `t_boxlabel` VALUES ('18', 'box303', '303', null, '0');
INSERT INTO `t_boxlabel` VALUES ('19', 'box304', '304', null, '0');
INSERT INTO `t_boxlabel` VALUES ('20', 'box305', '305', null, '0');
INSERT INTO `t_boxlabel` VALUES ('21', 'box306', '306', null, '0');
INSERT INTO `t_boxlabel` VALUES ('22', 'box307', '307', null, '0');
INSERT INTO `t_boxlabel` VALUES ('23', 'box308', '308', null, '0');

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
) ENGINE=InnoDB AUTO_INCREMENT=25 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_floorlabel
-- ----------------------------
INSERT INTO `t_floorlabel` VALUES ('4', 'floor2层架标签层架标签层架标签', '2', '3');
INSERT INTO `t_floorlabel` VALUES ('5', 'floor3层架标签层架标签层架标签', '3', '32');
INSERT INTO `t_floorlabel` VALUES ('6', '4', '4', '4');
INSERT INTO `t_floorlabel` VALUES ('7', '5', '5', '5');
INSERT INTO `t_floorlabel` VALUES ('8', '6', '6', '6');
INSERT INTO `t_floorlabel` VALUES ('9', '7', '7', '7');
INSERT INTO `t_floorlabel` VALUES ('10', '8', '8', '8');
INSERT INTO `t_floorlabel` VALUES ('11', '9', '9', '9');
INSERT INTO `t_floorlabel` VALUES ('12', '10', '10', '10');
INSERT INTO `t_floorlabel` VALUES ('13', '11', '11', null);
INSERT INTO `t_floorlabel` VALUES ('14', '12', '12', null);
INSERT INTO `t_floorlabel` VALUES ('15', '13', '13', null);
INSERT INTO `t_floorlabel` VALUES ('16', '14', '14', null);
INSERT INTO `t_floorlabel` VALUES ('17', '15', '15', null);
INSERT INTO `t_floorlabel` VALUES ('18', '16', '16', null);
INSERT INTO `t_floorlabel` VALUES ('20', '18', '18', null);
INSERT INTO `t_floorlabel` VALUES ('21', '19', '19', null);
INSERT INTO `t_floorlabel` VALUES ('24', 'floor1', '1', '1');

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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_inventory
-- ----------------------------
INSERT INTO `t_inventory` VALUES ('1', 'nannan_2016-02-17-16-05-21_????', '3', 'nannan', '2016-02-17 16:06:00');
INSERT INTO `t_inventory` VALUES ('2', 'nannan_2016-02-17-16-08-45_盘点记录', '3', 'nannan', '2016-02-17 16:08:49');

-- ----------------------------
-- Table structure for t_inventorydetail
-- ----------------------------
DROP TABLE IF EXISTS `t_inventorydetail`;
CREATE TABLE `t_inventorydetail` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mid` int(11) NOT NULL,
  `floorrfid` varchar(100) NOT NULL,
  `boxrfid` varchar(100) NOT NULL,
  `status` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_inventorydetail
-- ----------------------------
INSERT INTO `t_inventorydetail` VALUES ('1', '1', '3', '300', '??');
INSERT INTO `t_inventorydetail` VALUES ('2', '1', '3', '301', '??');
INSERT INTO `t_inventorydetail` VALUES ('3', '1', '3', '302', '??');
INSERT INTO `t_inventorydetail` VALUES ('4', '1', '3', '303', '??');
INSERT INTO `t_inventorydetail` VALUES ('5', '1', '3', '304', '??');
INSERT INTO `t_inventorydetail` VALUES ('6', '1', '3', '305', '??');
INSERT INTO `t_inventorydetail` VALUES ('7', '1', '3', '306', '??');
INSERT INTO `t_inventorydetail` VALUES ('8', '1', '3', '307', '??');
INSERT INTO `t_inventorydetail` VALUES ('9', '1', '3', '308', '??');
INSERT INTO `t_inventorydetail` VALUES ('10', '1', '1', '213', '??');
INSERT INTO `t_inventorydetail` VALUES ('11', '1', '1', '216', '??');
INSERT INTO `t_inventorydetail` VALUES ('12', '1', '1', '217', '??');
INSERT INTO `t_inventorydetail` VALUES ('13', '1', '1', '218', '??');
INSERT INTO `t_inventorydetail` VALUES ('14', '1', '1', '219', '??');
INSERT INTO `t_inventorydetail` VALUES ('15', '2', '3', '300', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('16', '2', '3', '301', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('17', '2', '3', '302', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('18', '2', '3', '303', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('19', '2', '3', '304', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('20', '2', '3', '305', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('21', '2', '3', '306', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('22', '2', '3', '307', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('23', '2', '3', '308', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('24', '2', '1', '213', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('25', '2', '1', '216', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('26', '2', '1', '217', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('27', '2', '1', '218', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('28', '2', '1', '219', '损坏');

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
INSERT INTO `t_position` VALUES ('216', '1');
INSERT INTO `t_position` VALUES ('213', '1');
INSERT INTO `t_position` VALUES ('217', '1');
INSERT INTO `t_position` VALUES ('218', '1');
INSERT INTO `t_position` VALUES ('219', '1');
INSERT INTO `t_position` VALUES ('214', '2');
INSERT INTO `t_position` VALUES ('300', '3');
INSERT INTO `t_position` VALUES ('301', '3');
INSERT INTO `t_position` VALUES ('302', '3');
INSERT INTO `t_position` VALUES ('303', '3');
INSERT INTO `t_position` VALUES ('304', '3');
INSERT INTO `t_position` VALUES ('305', '3');
INSERT INTO `t_position` VALUES ('306', '3');
INSERT INTO `t_position` VALUES ('307', '3');
INSERT INTO `t_position` VALUES ('308', '3');

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
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'admin', '123456', '金向东', '男', '13757193476', '30', null, '2016-01-16 13:16:31', 'admin', '2016-01-23 20:19:05', 'admin', '1', null);
INSERT INTO `t_user` VALUES ('2', 'jxd', '123456', 'jxd', '男', null, '30', null, '2016-01-16 15:20:56', 'admin', '2016-01-16 15:20:56', 'admin', '0', null);
INSERT INTO `t_user` VALUES ('3', 'nannan', '123456', '南南', '女', '18857155121', '30', null, '2016-01-24 19:02:53', 'admin', '2016-01-24 19:02:53', 'admin', '1', null);

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark,
 b.name as boxname , c.boxrfid , d.name as floorname , c.floorrfid  , CONCAT (d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ;

-- ----------------------------
-- View structure for v_box
-- ----------------------------
DROP VIEW IF EXISTS `v_box`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_box` AS select a.id , a.name,a.number , a.rfid , b.floorrfid from t_boxlabel a LEFT JOIN t_position b on a.rfid= b.boxrfid ;
