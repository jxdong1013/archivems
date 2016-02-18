/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2016-02-18 20:50:50
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
) ENGINE=InnoDB AUTO_INCREMENT=147 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_archive
-- ----------------------------
INSERT INTO `t_archive` VALUES ('22', '1', '扬州市申遗办', '淮扬运河扬州段遗产介绍', '4', '3210000101010010120130530', null, 'admin', '2016-01-16 22:22:57', '23');
INSERT INTO `t_archive` VALUES ('23', '2', '扬州市申遗办', '古邗沟故道（邗沟东道）遗产介绍', '1', '3210230101010020120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('24', '3', '扬州市申遗办', '高邮明清大运河故道遗产介绍', '2', '3210840101010030120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('25', '4', '扬州市申遗办', '邵伯明清大运河故道遗产介绍', '1', '3210120101010040120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('26', '5', '扬州市申遗办', '扬州古运河遗产介绍', '1', '3210000101010050120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('27', '6', '扬州市申遗办', '瓜洲运河遗产介绍', '1', '3210030101010060120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('28', '7', '扬州市申遗办', '刘堡减水闸遗产介绍', '5', '3210230102010010320130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('29', '8', '扬州市申遗办', '盂城驿遗产介绍', '2', '3210840103010010120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('30', '9', '扬州市申遗办', '邵伯古堤遗产介绍', '1', '3210120104010010120130530', ' ', 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('31', '10', '扬州市申遗办', '邵伯码头遗产介绍', '1', '3210120105010010120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('32', '11', '扬州市申遗办', '瘦西湖遗产介绍', '6', '3210000106010010120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('33', '12', '扬州市申遗办', '瘦西湖风景区概况', '33', '3210000106010020120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('34', '13', '扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆扬州博物馆', '《广陵名胜全图》节选', '31', '3210000106010030120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('35', '14', '扬州市申遗办', '扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介扬州历史城壕（保障河）文化景观主要遗存点简介', '24', '3210000106010040120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('36', '15', '扬州市申遗办', '天宁寺遗产介绍', '2', '3210030107010010120130530', null, 'admin', '2016-01-16 22:22:57', '15');
INSERT INTO `t_archive` VALUES ('37', '16', '扬州市申遗办', '重宁寺遗产介绍', '1', '3210030107010020120130530', null, 'admin', '2016-01-16 22:22:57', '19');
INSERT INTO `t_archive` VALUES ('38', '17', '扬州市申遗办', '盐业历史遗迹—个园遗产介绍', '5', '3210020108010010120130530', null, 'admin', '2016-01-16 22:22:57', '19');
INSERT INTO `t_archive` VALUES ('39', '18', '扬州市申遗办', '个园概况', '10', '3210020108010020120130530', null, 'admin', '2016-01-16 22:22:57', '19');
INSERT INTO `t_archive` VALUES ('40', '19', '刘凤诰', '个园记', '1', '3210020108010030120130530', null, 'admin', '2016-01-16 22:22:57', '19');
INSERT INTO `t_archive` VALUES ('41', '20', '扬州市申遗办', '个园楹联全编', '6', '3210020108010040120130530', null, 'admin', '2016-01-17 10:26:18', '15');
INSERT INTO `t_archive` VALUES ('42', '21', '扬州市申遗办', '盐业历史遗迹—汪鲁门遗产介绍', '1', '3210020109010010120130530', null, 'admin', '2016-01-17 10:26:19', '15');
INSERT INTO `t_archive` VALUES ('43', '22', '扬州市申遗办', '世德堂：盐商汪鲁门住宅', '5', '3210020109010020120130530', null, 'admin', '2016-01-17 10:26:19', '15');
INSERT INTO `t_archive` VALUES ('44', '23', '扬州市申遗办', '盐业历史遗迹—盐宗庙遗产介绍', '1', '3210020110010010120130530', null, 'admin', '2016-01-17 10:26:19', '15');
INSERT INTO `t_archive` VALUES ('45', '24', '扬州市申遗办', '盐业历史遗迹—卢绍绪盐商住宅遗产介绍', '1', '3210020111010010120130530', ' ', 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('46', '25', '扬州市申遗办', '淮扬运河扬州段历史沿革', '8', '3210000101020010120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('47', '26', '扬州市申遗办', '古邗沟故道（邗沟东道）历史沿革', '1', '3210230101020020120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('48', '27', '扬州市申遗办', '高邮明清大运河故道历史沿革', '1', '3210840101020030120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('49', '28', '扬州市申遗办', '邵伯明清大运河故道历史沿革', '1', '3210120101020040120130530', null, 'admin', '2016-01-17 10:26:19', '19');
INSERT INTO `t_archive` VALUES ('50', '29', '扬州市申遗办', '扬州古运河历史沿革', '1', '3210000101020050120130530', null, 'admin', '2016-01-17 10:26:19', '19');
INSERT INTO `t_archive` VALUES ('51', '30', '扬州市申遗办', '瓜洲运河历史沿革', '1', '3210030101020060120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('52', '31', '扬州市申遗办', '刘堡减水闸历史沿革', '1', '3210230102020010120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('53', '32', '扬州市申遗办', '盂城驿历史沿革', '1', '3210840103020010120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('54', '33', '扬州市申遗办', '邵伯古堤历史沿革', '1', '3210120104020010120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('55', '34', '扬州市申遗办', '邵伯码头遗产历史沿革', '1', '3210120105020010120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('56', '35', '扬州市申遗办', '瘦西湖历史沿革', '3', '3010000106020010120130530', null, 'admin', '2016-01-17 10:26:19', '17');
INSERT INTO `t_archive` VALUES ('57', '36', '扬州市申遗办', '天宁寺历史沿革', '1', '3210030107020010120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('58', '37', '扬州市申遗办', '重宁寺历史沿革', '1', '3210030107020020120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('59', '38', '扬州市申遗办', '个园历史沿革(1)', '1', '3210020108020010120130530', null, 'admin', '2016-01-17 10:26:19', '9');
INSERT INTO `t_archive` VALUES ('60', '39', '扬州市申遗办', '个园历史沿革(2)', '6', '3210020108020020120130530', null, 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('61', '40', '扬州市申遗办', '汪鲁门历史沿革', '1', '3210020109020010120130530', null, 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('62', '41', '江苏财政厅', '汪鲁门民国八年房契', '2', '3210020109020020120130530', '民国八年', 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('63', '42', '扬州市申遗办', '汪鲁门平面示意图', '1', '3210020109020030120130530', null, 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('64', '43', '扬州市申遗办', '汪鲁门平面图', '7', '3210020109020040120130530', '39083', 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('65', '44', '汪明', '缅怀嗣祖父——汪鲁门', '5', '3210020109020050120130530', null, 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('66', '45', '葛星明', '世德堂：盐商汪鲁门住宅', '2', '3210020109020060120130530', null, 'admin', '2016-01-17 10:26:19', '8');
INSERT INTO `t_archive` VALUES ('67', '1', '杭州市申遗办金向东', '杭州市西湖文化遗址65552221', '312', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('68', '2', '杭州市申遗办金向东', '杭州市西湖文化遗址65552222', '313', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('69', '3', '杭州市申遗办金向东', '杭州市西湖文化遗址65552223', '314', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('70', '4', '杭州市申遗办金向东', '杭州市西湖文化遗址65552224', '315', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('71', '5', '杭州市申遗办金向东', '杭州市西湖文化遗址65552225', '316', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('72', '6', '杭州市申遗办金向东', '杭州市西湖文化遗址65552226', '317', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('73', '7', '杭州市申遗办金向东', '杭州市西湖文化遗址65552227', '318', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('74', '8', '杭州市申遗办金向东', '杭州市西湖文化遗址65552228', '319', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('75', '9', '杭州市申遗办金向东', '杭州市西湖文化遗址65552229', '320', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('76', '10', '杭州市申遗办金向东', '杭州市西湖文化遗址65552230', '321', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('77', '11', '杭州市申遗办金向东', '杭州市西湖文化遗址65552231', '322', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('78', '12', '杭州市申遗办金向东', '杭州市西湖文化遗址65552232', '323', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('79', '13', '杭州市申遗办金向东', '杭州市西湖文化遗址65552233', '324', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('80', '14', '杭州市申遗办金向东', '杭州市西湖文化遗址65552234', '325', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('81', '15', '杭州市申遗办金向东', '杭州市西湖文化遗址65552235', '326', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('82', '16', '杭州市申遗办金向东', '杭州市西湖文化遗址65552236', '327', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('83', '17', '杭州市申遗办金向东', '杭州市西湖文化遗址65552237', '328', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('84', '18', '杭州市申遗办金向东', '杭州市西湖文化遗址65552238', '329', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('85', '19', '杭州市申遗办金向东', '杭州市西湖文化遗址65552239', '330', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('86', '20', '杭州市申遗办金向东', '杭州市西湖文化遗址65552240', '331', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('87', '21', '杭州市申遗办金向东', '杭州市西湖文化遗址65552241', '332', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('88', '22', '杭州市申遗办金向东', '杭州市西湖文化遗址65552242', '333', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('89', '23', '杭州市申遗办金向东', '杭州市西湖文化遗址65552243', '334', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('90', '24', '杭州市申遗办金向东', '杭州市西湖文化遗址65552244', '335', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('91', '25', '杭州市申遗办金向东', '杭州市西湖文化遗址65552245', '336', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('92', '26', '杭州市申遗办金向东', '杭州市西湖文化遗址65552246', '337', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('93', '27', '杭州市申遗办金向东', '杭州市西湖文化遗址65552247', '338', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('94', '28', '杭州市申遗办金向东', '杭州市西湖文化遗址65552248', '339', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('95', '29', '杭州市申遗办金向东', '杭州市西湖文化遗址65552249', '340', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('96', '30', '杭州市申遗办金向东', '杭州市西湖文化遗址65552250', '341', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('97', '31', '杭州市申遗办金向东', '杭州市西湖文化遗址65552251', '342', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('98', '32', '杭州市申遗办金向东', '杭州市西湖文化遗址65552252', '343', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('99', '33', '杭州市申遗办金向东', '杭州市西湖文化遗址65552253', '344', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('100', '34', '杭州市申遗办金向东', '杭州市西湖文化遗址65552254', '345', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('101', '35', '杭州市申遗办金向东', '杭州市西湖文化遗址65552255', '346', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('102', '36', '杭州市申遗办金向东', '杭州市西湖文化遗址65552256', '347', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('103', '37', '杭州市申遗办金向东', '杭州市西湖文化遗址65552257', '348', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('104', '38', '杭州市申遗办金向东', '杭州市西湖文化遗址65552258', '349', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('105', '39', '杭州市申遗办金向东', '杭州市西湖文化遗址65552259', '350', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('106', '40', '杭州市申遗办金向东', '杭州市西湖文化遗址65552260', '351', '4535345345345345', '', 'jxd', '2016-02-18 11:13:18', '0');
INSERT INTO `t_archive` VALUES ('107', '1', '杭州市申遗办金向东', '北京市西湖文化遗址65552221', '312', '4535345345345345', null, 'nannan', '2016-02-18 11:15:14', '0');
INSERT INTO `t_archive` VALUES ('108', '2', '杭州市申遗办金向东', '北京市西湖文化遗址65552222', '313', '4535345345345345', null, 'nannan', '2016-02-18 11:15:14', '0');
INSERT INTO `t_archive` VALUES ('109', '3', '杭州市申遗办金向东', '北京市西湖文化遗址65552223', '314', '4535345345345345', null, 'nannan', '2016-02-18 11:15:14', '0');
INSERT INTO `t_archive` VALUES ('110', '4', '杭州市申遗办金向东', '北京市西湖文化遗址65552224', '315', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('111', '5', '杭州市申遗办金向东', '北京市西湖文化遗址65552225', '316', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('112', '6', '杭州市申遗办金向东', '北京市西湖文化遗址65552226', '317', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('113', '7', '杭州市申遗办金向东', '北京市西湖文化遗址65552227', '318', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('114', '8', '杭州市申遗办金向东', '北京市西湖文化遗址65552228', '319', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('115', '9', '杭州市申遗办金向东', '北京市西湖文化遗址65552229', '320', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('116', '10', '杭州市申遗办金向东', '北京市西湖文化遗址65552230', '321', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('117', '11', '杭州市申遗办金向东', '北京市西湖文化遗址65552231', '322', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('118', '12', '杭州市申遗办金向东', '北京市西湖文化遗址65552232', '323', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('119', '13', '杭州市申遗办金向东', '北京市西湖文化遗址65552233', '324', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('120', '14', '杭州市申遗办金向东', '北京市西湖文化遗址65552234', '325', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('121', '15', '杭州市申遗办金向东', '北京市西湖文化遗址65552235', '326', '4535345345345345', null, 'nannan', '2016-02-18 11:15:15', '0');
INSERT INTO `t_archive` VALUES ('122', '16', '杭州市申遗办金向东', '北京市西湖文化遗址65552236', '327', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('123', '17', '杭州市申遗办金向东', '北京市西湖文化遗址65552237', '328', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('124', '18', '杭州市申遗办金向东', '北京市西湖文化遗址65552238', '329', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('125', '19', '杭州市申遗办金向东', '北京市西湖文化遗址65552239', '330', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('126', '20', '杭州市申遗办金向东', '北京市西湖文化遗址65552240', '331', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('127', '21', '杭州市申遗办金向东', '北京市西湖文化遗址65552241', '332', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('128', '22', '杭州市申遗办金向东', '北京市西湖文化遗址65552242', '333', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('129', '23', '杭州市申遗办金向东', '北京市西湖文化遗址65552243', '334', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('130', '24', '杭州市申遗办金向东', '北京市西湖文化遗址65552244', '335', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('131', '25', '杭州市申遗办金向东', '北京市西湖文化遗址65552245', '336', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('132', '26', '杭州市申遗办金向东', '北京市西湖文化遗址65552246', '337', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('133', '27', '杭州市申遗办金向东', '北京市西湖文化遗址65552247', '338', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('134', '28', '杭州市申遗办金向东', '北京市西湖文化遗址65552248', '339', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('135', '29', '杭州市申遗办金向东', '北京市西湖文化遗址65552249', '340', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('136', '30', '杭州市申遗办金向东', '北京市西湖文化遗址65552250', '341', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('137', '31', '杭州市申遗办金向东', '北京市西湖文化遗址65552251', '342', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('138', '32', '杭州市申遗办金向东', '北京市西湖文化遗址65552252', '343', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('139', '33', '杭州市申遗办金向东', '北京市西湖文化遗址65552253', '344', '4535345345345345', null, 'nannan', '2016-02-18 11:15:16', '0');
INSERT INTO `t_archive` VALUES ('140', '34', '杭州市申遗办金向东', '北京市西湖文化遗址65552254', '345', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('141', '35', '杭州市申遗办金向东', '北京市西湖文化遗址65552255', '346', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('142', '36', '杭州市申遗办金向东', '北京市西湖文化遗址65552256', '347', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('143', '37', '杭州市申遗办金向东', '北京市西湖文化遗址65552257', '348', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('144', '38', '杭州市申遗办金向东', '北京市西湖文化遗址65552258', '349', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('145', '39', '杭州市申遗办金向东', '北京市西湖文化遗址65552259', '350', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');
INSERT INTO `t_archive` VALUES ('146', '40', '杭州市申遗办金向东', '北京市西湖文化遗址65552260', '351', '4535345345345345', null, 'nannan', '2016-02-18 11:15:17', '0');

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
) ENGINE=InnoDB AUTO_INCREMENT=99 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_boxlabel
-- ----------------------------
INSERT INTO `t_boxlabel` VALUES ('8', 'box213档案盒档案盒档案盒档案盒', '213', null);
INSERT INTO `t_boxlabel` VALUES ('9', 'box214', '214', null);
INSERT INTO `t_boxlabel` VALUES ('10', 'box215', '215', null);
INSERT INTO `t_boxlabel` VALUES ('11', 'box216', '216', null);
INSERT INTO `t_boxlabel` VALUES ('12', 'box217', '217', null);
INSERT INTO `t_boxlabel` VALUES ('13', 'box218', '218', null);
INSERT INTO `t_boxlabel` VALUES ('14', 'box219', '219', null);
INSERT INTO `t_boxlabel` VALUES ('15', 'box300', '300', null);
INSERT INTO `t_boxlabel` VALUES ('16', 'box301', '301', null);
INSERT INTO `t_boxlabel` VALUES ('17', 'box302', '302', null);
INSERT INTO `t_boxlabel` VALUES ('18', 'box303', '303', null);
INSERT INTO `t_boxlabel` VALUES ('19', 'box304', '304', null);
INSERT INTO `t_boxlabel` VALUES ('20', 'box305', '305', null);
INSERT INTO `t_boxlabel` VALUES ('21', 'box306', '306', null);
INSERT INTO `t_boxlabel` VALUES ('22', 'box307', '307', null);
INSERT INTO `t_boxlabel` VALUES ('23', 'box308', '308', null);
INSERT INTO `t_boxlabel` VALUES ('24', 'box309', '309', null);
INSERT INTO `t_boxlabel` VALUES ('25', 'box310', '310', null);
INSERT INTO `t_boxlabel` VALUES ('26', 'box311', '311', null);
INSERT INTO `t_boxlabel` VALUES ('27', 'box312', '312', null);
INSERT INTO `t_boxlabel` VALUES ('28', 'box313', '313', null);
INSERT INTO `t_boxlabel` VALUES ('29', 'box314', '314', null);
INSERT INTO `t_boxlabel` VALUES ('30', 'box315', '315', null);
INSERT INTO `t_boxlabel` VALUES ('31', 'box316', '316', null);
INSERT INTO `t_boxlabel` VALUES ('32', 'box317', '317', null);
INSERT INTO `t_boxlabel` VALUES ('33', 'box318', '318', null);
INSERT INTO `t_boxlabel` VALUES ('34', 'box319', '319', null);
INSERT INTO `t_boxlabel` VALUES ('35', 'box320', '320', null);
INSERT INTO `t_boxlabel` VALUES ('36', 'box321', '321', null);
INSERT INTO `t_boxlabel` VALUES ('37', 'box322', '322', null);
INSERT INTO `t_boxlabel` VALUES ('38', 'box323', '323', null);
INSERT INTO `t_boxlabel` VALUES ('39', 'box324', '324', null);
INSERT INTO `t_boxlabel` VALUES ('40', 'box325', '325', null);
INSERT INTO `t_boxlabel` VALUES ('41', 'box326', '326', null);
INSERT INTO `t_boxlabel` VALUES ('42', 'box327', '327', null);
INSERT INTO `t_boxlabel` VALUES ('43', 'box328', '328', null);
INSERT INTO `t_boxlabel` VALUES ('44', 'box329', '329', null);
INSERT INTO `t_boxlabel` VALUES ('45', 'box330', '330', null);
INSERT INTO `t_boxlabel` VALUES ('46', 'box331', '331', null);
INSERT INTO `t_boxlabel` VALUES ('47', 'box332', '332', null);
INSERT INTO `t_boxlabel` VALUES ('48', 'box333', '333', null);
INSERT INTO `t_boxlabel` VALUES ('49', 'box334', '334', null);
INSERT INTO `t_boxlabel` VALUES ('50', 'box335', '335', null);
INSERT INTO `t_boxlabel` VALUES ('51', 'box336', '336', null);
INSERT INTO `t_boxlabel` VALUES ('52', 'box337', '337', null);
INSERT INTO `t_boxlabel` VALUES ('53', 'box338', '338', null);
INSERT INTO `t_boxlabel` VALUES ('54', 'box339', '339', null);
INSERT INTO `t_boxlabel` VALUES ('55', 'box340', '340', null);
INSERT INTO `t_boxlabel` VALUES ('56', 'box341', '341', null);
INSERT INTO `t_boxlabel` VALUES ('57', 'box342', '342', null);
INSERT INTO `t_boxlabel` VALUES ('58', 'box343', '343', null);
INSERT INTO `t_boxlabel` VALUES ('59', 'box344', '344', null);
INSERT INTO `t_boxlabel` VALUES ('60', 'box345', '345', null);
INSERT INTO `t_boxlabel` VALUES ('61', 'box346', '346', null);
INSERT INTO `t_boxlabel` VALUES ('62', 'box347', '347', null);
INSERT INTO `t_boxlabel` VALUES ('63', 'box348', '348', null);
INSERT INTO `t_boxlabel` VALUES ('64', 'box349', '349', null);
INSERT INTO `t_boxlabel` VALUES ('65', 'box350', '350', null);
INSERT INTO `t_boxlabel` VALUES ('66', 'box351', '351', null);
INSERT INTO `t_boxlabel` VALUES ('67', 'box352', '352', null);
INSERT INTO `t_boxlabel` VALUES ('68', 'box353', '353', null);
INSERT INTO `t_boxlabel` VALUES ('69', 'box354', '354', null);
INSERT INTO `t_boxlabel` VALUES ('70', 'box355', '355', null);
INSERT INTO `t_boxlabel` VALUES ('71', 'box356', '356', null);
INSERT INTO `t_boxlabel` VALUES ('72', 'box357', '357', null);
INSERT INTO `t_boxlabel` VALUES ('73', 'box358', '358', null);
INSERT INTO `t_boxlabel` VALUES ('74', 'box359', '359', null);
INSERT INTO `t_boxlabel` VALUES ('75', 'box360', '360', null);
INSERT INTO `t_boxlabel` VALUES ('76', 'box361', '361', null);
INSERT INTO `t_boxlabel` VALUES ('77', 'box362', '362', null);
INSERT INTO `t_boxlabel` VALUES ('78', 'box363', '363', null);
INSERT INTO `t_boxlabel` VALUES ('79', 'box364', '364', null);
INSERT INTO `t_boxlabel` VALUES ('80', 'box365', '365', null);
INSERT INTO `t_boxlabel` VALUES ('81', 'box366', '366', null);
INSERT INTO `t_boxlabel` VALUES ('82', 'box367', '367', null);
INSERT INTO `t_boxlabel` VALUES ('83', 'box368', '368', null);
INSERT INTO `t_boxlabel` VALUES ('84', 'box369', '369', null);
INSERT INTO `t_boxlabel` VALUES ('85', 'box370', '370', null);
INSERT INTO `t_boxlabel` VALUES ('86', 'box371', '371', null);
INSERT INTO `t_boxlabel` VALUES ('87', 'box372', '372', null);
INSERT INTO `t_boxlabel` VALUES ('88', 'box373', '373', null);
INSERT INTO `t_boxlabel` VALUES ('89', 'box374', '374', null);
INSERT INTO `t_boxlabel` VALUES ('90', 'box375', '375', null);
INSERT INTO `t_boxlabel` VALUES ('91', 'box376', '376', null);
INSERT INTO `t_boxlabel` VALUES ('92', 'box377', '377', null);
INSERT INTO `t_boxlabel` VALUES ('93', 'box378', '378', null);
INSERT INTO `t_boxlabel` VALUES ('94', 'box379', '379', null);
INSERT INTO `t_boxlabel` VALUES ('95', 'box380', '380', null);
INSERT INTO `t_boxlabel` VALUES ('96', 'box381', '381', null);
INSERT INTO `t_boxlabel` VALUES ('97', 'box382', '382', null);

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
) ENGINE=InnoDB AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_floorlabel
-- ----------------------------
INSERT INTO `t_floorlabel` VALUES ('4', '层架标签2', '200000002', '3');
INSERT INTO `t_floorlabel` VALUES ('5', '层架标签3', '200000003', '32');
INSERT INTO `t_floorlabel` VALUES ('6', '层架标签4', '200000004', '4');
INSERT INTO `t_floorlabel` VALUES ('7', '层架标签5', '200000005', '5');
INSERT INTO `t_floorlabel` VALUES ('8', '层架标签6', '200000006', '6');
INSERT INTO `t_floorlabel` VALUES ('9', '层架标签7', '200000007', '7');
INSERT INTO `t_floorlabel` VALUES ('10', '层架标签8', '200000008', '8');
INSERT INTO `t_floorlabel` VALUES ('11', '层架标签9', '200000009', '9');
INSERT INTO `t_floorlabel` VALUES ('12', '层架标签10', '200000010', '10');
INSERT INTO `t_floorlabel` VALUES ('13', '层架标签11', '200000011', null);
INSERT INTO `t_floorlabel` VALUES ('14', '层架标签12', '200000012', null);
INSERT INTO `t_floorlabel` VALUES ('15', '层架标签13', '200000013', null);
INSERT INTO `t_floorlabel` VALUES ('16', '层架标签14', '200000014', null);
INSERT INTO `t_floorlabel` VALUES ('17', '层架标签15', '200000015', null);
INSERT INTO `t_floorlabel` VALUES ('18', '层架标签16', '200000016', null);
INSERT INTO `t_floorlabel` VALUES ('20', '层架标签18', '200000018', null);
INSERT INTO `t_floorlabel` VALUES ('21', '层架标签19', '200000019', null);
INSERT INTO `t_floorlabel` VALUES ('24', '层架标签1', '200000001', '1');
INSERT INTO `t_floorlabel` VALUES ('25', '层架标签20', '200000020', null);
INSERT INTO `t_floorlabel` VALUES ('26', '层架标签21', '200000021', null);
INSERT INTO `t_floorlabel` VALUES ('27', '层架标签22', '200000022', null);
INSERT INTO `t_floorlabel` VALUES ('28', '层架标签23', '200000023', null);
INSERT INTO `t_floorlabel` VALUES ('29', '层架标签24', '200000024', null);
INSERT INTO `t_floorlabel` VALUES ('30', '层架标签25', '200000025', null);
INSERT INTO `t_floorlabel` VALUES ('31', '层架标签26', '200000026', null);
INSERT INTO `t_floorlabel` VALUES ('32', '层架标签27', '200000027', null);
INSERT INTO `t_floorlabel` VALUES ('33', '层架标签28', '200000028', null);
INSERT INTO `t_floorlabel` VALUES ('34', '层架标签29', '200000029', null);
INSERT INTO `t_floorlabel` VALUES ('35', '层架标签30', '200000030', null);
INSERT INTO `t_floorlabel` VALUES ('36', '层架标签31', '200000031', null);
INSERT INTO `t_floorlabel` VALUES ('37', '层架标签32', '200000032', null);
INSERT INTO `t_floorlabel` VALUES ('38', '层架标签33', '200000033', null);
INSERT INTO `t_floorlabel` VALUES ('39', '层架标签34', '200000034', null);
INSERT INTO `t_floorlabel` VALUES ('40', '层架标签35', '200000035', null);
INSERT INTO `t_floorlabel` VALUES ('41', '层架标签36', '200000036', null);
INSERT INTO `t_floorlabel` VALUES ('42', '层架标签37', '200000037', null);
INSERT INTO `t_floorlabel` VALUES ('43', '层架标签38', '200000038', null);
INSERT INTO `t_floorlabel` VALUES ('44', '层架标签39', '200000039', null);
INSERT INTO `t_floorlabel` VALUES ('45', '层架标签40', '200000040', null);
INSERT INTO `t_floorlabel` VALUES ('46', '层架标签41', '200000041', null);
INSERT INTO `t_floorlabel` VALUES ('47', '层架标签42', '200000042', null);
INSERT INTO `t_floorlabel` VALUES ('48', '层架标签43', '200000043', null);
INSERT INTO `t_floorlabel` VALUES ('49', '层架标签44', '200000044', null);
INSERT INTO `t_floorlabel` VALUES ('50', '层架标签45', '200000045', null);
INSERT INTO `t_floorlabel` VALUES ('51', '层架标签46', '200000046', null);
INSERT INTO `t_floorlabel` VALUES ('52', '层架标签47', '200000047', null);
INSERT INTO `t_floorlabel` VALUES ('53', '层架标签48', '200000048', null);
INSERT INTO `t_floorlabel` VALUES ('54', '层架标签49', '200000049', null);

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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_inventory
-- ----------------------------
INSERT INTO `t_inventory` VALUES ('1', 'nannan_2016-02-17-16-05-21_????', '3', 'nannan', '2016-02-17 16:06:00');
INSERT INTO `t_inventory` VALUES ('2', 'nannan_2016-02-17-16-08-45_盘点记录', '3', 'nannan', '2016-02-17 16:08:49');
INSERT INTO `t_inventory` VALUES ('3', 'nannan_2016-02-18-16-35-42_盘点记录', '3', 'nannan', '2016-02-18 16:35:33');
INSERT INTO `t_inventory` VALUES ('4', 'nannan_2016-02-18-16-42-32_盘点记录', '3', 'nannan', '2016-02-18 16:42:56');

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
) ENGINE=InnoDB AUTO_INCREMENT=205 DEFAULT CHARSET=utf8;

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
INSERT INTO `t_inventorydetail` VALUES ('29', '3', '1', '213', '正常');
INSERT INTO `t_inventorydetail` VALUES ('30', '3', '1', '216', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('31', '3', '1', '217', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('32', '3', '1', '218', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('33', '3', '1', '219', '正常');
INSERT INTO `t_inventorydetail` VALUES ('34', '3', '200000003', '300', null);
INSERT INTO `t_inventorydetail` VALUES ('35', '3', '200000003', '301', null);
INSERT INTO `t_inventorydetail` VALUES ('36', '3', '200000003', '302', '正常');
INSERT INTO `t_inventorydetail` VALUES ('37', '3', '200000003', '303', '正常');
INSERT INTO `t_inventorydetail` VALUES ('38', '3', '200000003', '304', null);
INSERT INTO `t_inventorydetail` VALUES ('39', '3', '200000003', '305', null);
INSERT INTO `t_inventorydetail` VALUES ('40', '3', '200000003', '306', null);
INSERT INTO `t_inventorydetail` VALUES ('41', '3', '200000003', '307', null);
INSERT INTO `t_inventorydetail` VALUES ('42', '3', '200000003', '308', null);
INSERT INTO `t_inventorydetail` VALUES ('43', '3', '200000003', '309', null);
INSERT INTO `t_inventorydetail` VALUES ('44', '3', '200000003', '310', null);
INSERT INTO `t_inventorydetail` VALUES ('45', '3', '200000003', '311', null);
INSERT INTO `t_inventorydetail` VALUES ('46', '3', '200000003', '312', null);
INSERT INTO `t_inventorydetail` VALUES ('47', '3', '200000003', '313', null);
INSERT INTO `t_inventorydetail` VALUES ('48', '3', '200000003', '314', null);
INSERT INTO `t_inventorydetail` VALUES ('49', '3', '200000003', '315', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('50', '3', '200000003', '316', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('51', '3', '200000003', '317', null);
INSERT INTO `t_inventorydetail` VALUES ('52', '3', '200000003', '318', null);
INSERT INTO `t_inventorydetail` VALUES ('53', '3', '200000003', '319', null);
INSERT INTO `t_inventorydetail` VALUES ('54', '3', '200000003', '320', null);
INSERT INTO `t_inventorydetail` VALUES ('55', '3', '200000003', '321', null);
INSERT INTO `t_inventorydetail` VALUES ('56', '3', '200000003', '322', null);
INSERT INTO `t_inventorydetail` VALUES ('57', '3', '200000003', '323', null);
INSERT INTO `t_inventorydetail` VALUES ('58', '3', '200000003', '324', null);
INSERT INTO `t_inventorydetail` VALUES ('59', '3', '200000003', '325', null);
INSERT INTO `t_inventorydetail` VALUES ('60', '3', '200000003', '326', null);
INSERT INTO `t_inventorydetail` VALUES ('61', '3', '200000003', '327', null);
INSERT INTO `t_inventorydetail` VALUES ('62', '3', '200000003', '328', null);
INSERT INTO `t_inventorydetail` VALUES ('63', '3', '200000003', '329', null);
INSERT INTO `t_inventorydetail` VALUES ('64', '3', '200000003', '330', null);
INSERT INTO `t_inventorydetail` VALUES ('65', '3', '200000003', '331', null);
INSERT INTO `t_inventorydetail` VALUES ('66', '3', '200000003', '332', null);
INSERT INTO `t_inventorydetail` VALUES ('67', '3', '200000003', '333', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('68', '3', '200000003', '334', null);
INSERT INTO `t_inventorydetail` VALUES ('69', '3', '200000003', '335', null);
INSERT INTO `t_inventorydetail` VALUES ('70', '3', '200000003', '336', null);
INSERT INTO `t_inventorydetail` VALUES ('71', '3', '200000003', '337', null);
INSERT INTO `t_inventorydetail` VALUES ('72', '3', '200000003', '338', null);
INSERT INTO `t_inventorydetail` VALUES ('73', '3', '200000003', '339', null);
INSERT INTO `t_inventorydetail` VALUES ('74', '3', '200000003', '340', null);
INSERT INTO `t_inventorydetail` VALUES ('75', '3', '200000003', '341', null);
INSERT INTO `t_inventorydetail` VALUES ('76', '3', '200000003', '342', null);
INSERT INTO `t_inventorydetail` VALUES ('77', '3', '200000003', '343', null);
INSERT INTO `t_inventorydetail` VALUES ('78', '3', '200000003', '344', null);
INSERT INTO `t_inventorydetail` VALUES ('79', '3', '200000003', '345', null);
INSERT INTO `t_inventorydetail` VALUES ('80', '3', '200000003', '346', null);
INSERT INTO `t_inventorydetail` VALUES ('81', '3', '200000003', '347', null);
INSERT INTO `t_inventorydetail` VALUES ('82', '3', '200000003', '348', null);
INSERT INTO `t_inventorydetail` VALUES ('83', '3', '200000003', '349', null);
INSERT INTO `t_inventorydetail` VALUES ('84', '3', '200000003', '350', null);
INSERT INTO `t_inventorydetail` VALUES ('85', '3', '200000003', '351', null);
INSERT INTO `t_inventorydetail` VALUES ('86', '3', '200000003', '352', null);
INSERT INTO `t_inventorydetail` VALUES ('87', '3', '200000003', '353', null);
INSERT INTO `t_inventorydetail` VALUES ('88', '3', '200000003', '354', null);
INSERT INTO `t_inventorydetail` VALUES ('89', '3', '200000003', '355', null);
INSERT INTO `t_inventorydetail` VALUES ('90', '3', '200000003', '356', null);
INSERT INTO `t_inventorydetail` VALUES ('91', '3', '200000003', '357', null);
INSERT INTO `t_inventorydetail` VALUES ('92', '3', '200000003', '358', null);
INSERT INTO `t_inventorydetail` VALUES ('93', '3', '200000003', '359', null);
INSERT INTO `t_inventorydetail` VALUES ('94', '3', '200000003', '360', null);
INSERT INTO `t_inventorydetail` VALUES ('95', '3', '200000003', '361', null);
INSERT INTO `t_inventorydetail` VALUES ('96', '3', '200000003', '362', null);
INSERT INTO `t_inventorydetail` VALUES ('97', '3', '200000003', '363', null);
INSERT INTO `t_inventorydetail` VALUES ('98', '3', '200000003', '364', null);
INSERT INTO `t_inventorydetail` VALUES ('99', '3', '200000003', '365', null);
INSERT INTO `t_inventorydetail` VALUES ('100', '3', '200000003', '366', null);
INSERT INTO `t_inventorydetail` VALUES ('101', '3', '200000003', '367', null);
INSERT INTO `t_inventorydetail` VALUES ('102', '3', '200000003', '368', null);
INSERT INTO `t_inventorydetail` VALUES ('103', '3', '200000003', '369', null);
INSERT INTO `t_inventorydetail` VALUES ('104', '3', '200000003', '370', null);
INSERT INTO `t_inventorydetail` VALUES ('105', '3', '200000003', '371', null);
INSERT INTO `t_inventorydetail` VALUES ('106', '3', '200000003', '372', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('107', '3', '200000003', '373', null);
INSERT INTO `t_inventorydetail` VALUES ('108', '3', '200000003', '374', null);
INSERT INTO `t_inventorydetail` VALUES ('109', '3', '200000003', '375', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('110', '3', '200000003', '376', null);
INSERT INTO `t_inventorydetail` VALUES ('111', '3', '200000003', '377', '丢失');
INSERT INTO `t_inventorydetail` VALUES ('112', '3', '200000003', '378', null);
INSERT INTO `t_inventorydetail` VALUES ('113', '3', '200000003', '379', '损坏');
INSERT INTO `t_inventorydetail` VALUES ('114', '3', '200000003', '380', null);
INSERT INTO `t_inventorydetail` VALUES ('115', '3', '200000003', '381', null);
INSERT INTO `t_inventorydetail` VALUES ('116', '3', '200000003', '382', null);
INSERT INTO `t_inventorydetail` VALUES ('117', '4', '200000003', '300', null);
INSERT INTO `t_inventorydetail` VALUES ('118', '4', '200000003', '301', null);
INSERT INTO `t_inventorydetail` VALUES ('119', '4', '200000003', '302', null);
INSERT INTO `t_inventorydetail` VALUES ('120', '4', '200000003', '303', null);
INSERT INTO `t_inventorydetail` VALUES ('121', '4', '200000003', '304', null);
INSERT INTO `t_inventorydetail` VALUES ('122', '4', '200000003', '305', null);
INSERT INTO `t_inventorydetail` VALUES ('123', '4', '200000003', '306', null);
INSERT INTO `t_inventorydetail` VALUES ('124', '4', '200000003', '307', null);
INSERT INTO `t_inventorydetail` VALUES ('125', '4', '200000003', '308', null);
INSERT INTO `t_inventorydetail` VALUES ('126', '4', '200000003', '309', null);
INSERT INTO `t_inventorydetail` VALUES ('127', '4', '200000003', '310', null);
INSERT INTO `t_inventorydetail` VALUES ('128', '4', '200000003', '311', null);
INSERT INTO `t_inventorydetail` VALUES ('129', '4', '200000003', '312', null);
INSERT INTO `t_inventorydetail` VALUES ('130', '4', '200000003', '313', null);
INSERT INTO `t_inventorydetail` VALUES ('131', '4', '200000003', '314', null);
INSERT INTO `t_inventorydetail` VALUES ('132', '4', '200000003', '315', null);
INSERT INTO `t_inventorydetail` VALUES ('133', '4', '200000003', '316', null);
INSERT INTO `t_inventorydetail` VALUES ('134', '4', '200000003', '317', null);
INSERT INTO `t_inventorydetail` VALUES ('135', '4', '200000003', '318', null);
INSERT INTO `t_inventorydetail` VALUES ('136', '4', '200000003', '319', null);
INSERT INTO `t_inventorydetail` VALUES ('137', '4', '200000003', '320', null);
INSERT INTO `t_inventorydetail` VALUES ('138', '4', '200000003', '321', null);
INSERT INTO `t_inventorydetail` VALUES ('139', '4', '200000003', '322', null);
INSERT INTO `t_inventorydetail` VALUES ('140', '4', '200000003', '323', null);
INSERT INTO `t_inventorydetail` VALUES ('141', '4', '200000003', '324', null);
INSERT INTO `t_inventorydetail` VALUES ('142', '4', '200000003', '325', null);
INSERT INTO `t_inventorydetail` VALUES ('143', '4', '200000003', '326', null);
INSERT INTO `t_inventorydetail` VALUES ('144', '4', '200000003', '327', null);
INSERT INTO `t_inventorydetail` VALUES ('145', '4', '200000003', '328', null);
INSERT INTO `t_inventorydetail` VALUES ('146', '4', '200000003', '329', null);
INSERT INTO `t_inventorydetail` VALUES ('147', '4', '200000003', '330', null);
INSERT INTO `t_inventorydetail` VALUES ('148', '4', '200000003', '331', null);
INSERT INTO `t_inventorydetail` VALUES ('149', '4', '200000003', '332', null);
INSERT INTO `t_inventorydetail` VALUES ('150', '4', '200000003', '333', null);
INSERT INTO `t_inventorydetail` VALUES ('151', '4', '200000003', '334', null);
INSERT INTO `t_inventorydetail` VALUES ('152', '4', '200000003', '335', null);
INSERT INTO `t_inventorydetail` VALUES ('153', '4', '200000003', '336', null);
INSERT INTO `t_inventorydetail` VALUES ('154', '4', '200000003', '337', null);
INSERT INTO `t_inventorydetail` VALUES ('155', '4', '200000003', '338', null);
INSERT INTO `t_inventorydetail` VALUES ('156', '4', '200000003', '339', null);
INSERT INTO `t_inventorydetail` VALUES ('157', '4', '200000003', '340', null);
INSERT INTO `t_inventorydetail` VALUES ('158', '4', '200000003', '341', null);
INSERT INTO `t_inventorydetail` VALUES ('159', '4', '200000003', '342', null);
INSERT INTO `t_inventorydetail` VALUES ('160', '4', '200000003', '343', null);
INSERT INTO `t_inventorydetail` VALUES ('161', '4', '200000003', '344', null);
INSERT INTO `t_inventorydetail` VALUES ('162', '4', '200000003', '345', null);
INSERT INTO `t_inventorydetail` VALUES ('163', '4', '200000003', '346', null);
INSERT INTO `t_inventorydetail` VALUES ('164', '4', '200000003', '347', null);
INSERT INTO `t_inventorydetail` VALUES ('165', '4', '200000003', '348', null);
INSERT INTO `t_inventorydetail` VALUES ('166', '4', '200000003', '349', null);
INSERT INTO `t_inventorydetail` VALUES ('167', '4', '200000003', '350', null);
INSERT INTO `t_inventorydetail` VALUES ('168', '4', '200000003', '351', null);
INSERT INTO `t_inventorydetail` VALUES ('169', '4', '200000003', '352', null);
INSERT INTO `t_inventorydetail` VALUES ('170', '4', '200000003', '353', null);
INSERT INTO `t_inventorydetail` VALUES ('171', '4', '200000003', '354', null);
INSERT INTO `t_inventorydetail` VALUES ('172', '4', '200000003', '355', null);
INSERT INTO `t_inventorydetail` VALUES ('173', '4', '200000003', '356', null);
INSERT INTO `t_inventorydetail` VALUES ('174', '4', '200000003', '357', null);
INSERT INTO `t_inventorydetail` VALUES ('175', '4', '200000003', '358', null);
INSERT INTO `t_inventorydetail` VALUES ('176', '4', '200000003', '359', null);
INSERT INTO `t_inventorydetail` VALUES ('177', '4', '200000003', '360', null);
INSERT INTO `t_inventorydetail` VALUES ('178', '4', '200000003', '361', null);
INSERT INTO `t_inventorydetail` VALUES ('179', '4', '200000003', '362', null);
INSERT INTO `t_inventorydetail` VALUES ('180', '4', '200000003', '363', null);
INSERT INTO `t_inventorydetail` VALUES ('181', '4', '200000003', '364', null);
INSERT INTO `t_inventorydetail` VALUES ('182', '4', '200000003', '365', null);
INSERT INTO `t_inventorydetail` VALUES ('183', '4', '200000003', '366', null);
INSERT INTO `t_inventorydetail` VALUES ('184', '4', '200000003', '367', null);
INSERT INTO `t_inventorydetail` VALUES ('185', '4', '200000003', '368', null);
INSERT INTO `t_inventorydetail` VALUES ('186', '4', '200000003', '369', null);
INSERT INTO `t_inventorydetail` VALUES ('187', '4', '200000003', '370', null);
INSERT INTO `t_inventorydetail` VALUES ('188', '4', '200000003', '371', null);
INSERT INTO `t_inventorydetail` VALUES ('189', '4', '200000003', '372', null);
INSERT INTO `t_inventorydetail` VALUES ('190', '4', '200000003', '373', null);
INSERT INTO `t_inventorydetail` VALUES ('191', '4', '200000003', '374', null);
INSERT INTO `t_inventorydetail` VALUES ('192', '4', '200000003', '375', null);
INSERT INTO `t_inventorydetail` VALUES ('193', '4', '200000003', '376', null);
INSERT INTO `t_inventorydetail` VALUES ('194', '4', '200000003', '377', null);
INSERT INTO `t_inventorydetail` VALUES ('195', '4', '200000003', '378', null);
INSERT INTO `t_inventorydetail` VALUES ('196', '4', '200000003', '379', null);
INSERT INTO `t_inventorydetail` VALUES ('197', '4', '200000003', '380', null);
INSERT INTO `t_inventorydetail` VALUES ('198', '4', '200000003', '381', null);
INSERT INTO `t_inventorydetail` VALUES ('199', '4', '200000003', '382', null);
INSERT INTO `t_inventorydetail` VALUES ('200', '4', '200000001', '213', '正常');
INSERT INTO `t_inventorydetail` VALUES ('201', '4', '200000001', '216', '正常');
INSERT INTO `t_inventorydetail` VALUES ('202', '4', '200000001', '217', '正常');
INSERT INTO `t_inventorydetail` VALUES ('203', '4', '200000001', '218', '正常');
INSERT INTO `t_inventorydetail` VALUES ('204', '4', '200000001', '219', '正常');

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
INSERT INTO `t_position` VALUES ('216', '200000001');
INSERT INTO `t_position` VALUES ('213', '200000001');
INSERT INTO `t_position` VALUES ('217', '200000001');
INSERT INTO `t_position` VALUES ('218', '200000001');
INSERT INTO `t_position` VALUES ('219', '200000001');
INSERT INTO `t_position` VALUES ('214', '200000002');
INSERT INTO `t_position` VALUES ('300', '200000003');
INSERT INTO `t_position` VALUES ('301', '200000003');
INSERT INTO `t_position` VALUES ('302', '200000003');
INSERT INTO `t_position` VALUES ('303', '200000003');
INSERT INTO `t_position` VALUES ('304', '200000003');
INSERT INTO `t_position` VALUES ('305', '200000003');
INSERT INTO `t_position` VALUES ('306', '200000003');
INSERT INTO `t_position` VALUES ('307', '200000003');
INSERT INTO `t_position` VALUES ('308', '200000003');
INSERT INTO `t_position` VALUES ('309', '200000003');
INSERT INTO `t_position` VALUES ('310', '200000003');
INSERT INTO `t_position` VALUES ('311', '200000003');
INSERT INTO `t_position` VALUES ('312', '200000003');
INSERT INTO `t_position` VALUES ('313', '200000003');
INSERT INTO `t_position` VALUES ('314', '200000003');
INSERT INTO `t_position` VALUES ('315', '200000003');
INSERT INTO `t_position` VALUES ('316', '200000003');
INSERT INTO `t_position` VALUES ('317', '200000003');
INSERT INTO `t_position` VALUES ('318', '200000003');
INSERT INTO `t_position` VALUES ('319', '200000003');
INSERT INTO `t_position` VALUES ('320', '200000003');
INSERT INTO `t_position` VALUES ('321', '200000003');
INSERT INTO `t_position` VALUES ('322', '200000003');
INSERT INTO `t_position` VALUES ('323', '200000003');
INSERT INTO `t_position` VALUES ('324', '200000003');
INSERT INTO `t_position` VALUES ('325', '200000003');
INSERT INTO `t_position` VALUES ('326', '200000003');
INSERT INTO `t_position` VALUES ('327', '200000003');
INSERT INTO `t_position` VALUES ('328', '200000003');
INSERT INTO `t_position` VALUES ('329', '200000003');
INSERT INTO `t_position` VALUES ('330', '200000003');
INSERT INTO `t_position` VALUES ('331', '200000003');
INSERT INTO `t_position` VALUES ('332', '200000003');
INSERT INTO `t_position` VALUES ('333', '200000003');
INSERT INTO `t_position` VALUES ('334', '200000003');
INSERT INTO `t_position` VALUES ('335', '200000003');
INSERT INTO `t_position` VALUES ('336', '200000003');
INSERT INTO `t_position` VALUES ('337', '200000003');
INSERT INTO `t_position` VALUES ('338', '200000003');
INSERT INTO `t_position` VALUES ('339', '200000003');
INSERT INTO `t_position` VALUES ('340', '200000003');
INSERT INTO `t_position` VALUES ('341', '200000003');
INSERT INTO `t_position` VALUES ('342', '200000003');
INSERT INTO `t_position` VALUES ('343', '200000003');
INSERT INTO `t_position` VALUES ('344', '200000003');
INSERT INTO `t_position` VALUES ('345', '200000003');
INSERT INTO `t_position` VALUES ('346', '200000003');
INSERT INTO `t_position` VALUES ('347', '200000003');
INSERT INTO `t_position` VALUES ('348', '200000003');
INSERT INTO `t_position` VALUES ('349', '200000003');
INSERT INTO `t_position` VALUES ('350', '200000003');
INSERT INTO `t_position` VALUES ('351', '200000003');
INSERT INTO `t_position` VALUES ('352', '200000003');
INSERT INTO `t_position` VALUES ('353', '200000003');
INSERT INTO `t_position` VALUES ('354', '200000003');
INSERT INTO `t_position` VALUES ('355', '200000003');
INSERT INTO `t_position` VALUES ('356', '200000003');
INSERT INTO `t_position` VALUES ('357', '200000003');
INSERT INTO `t_position` VALUES ('358', '200000003');
INSERT INTO `t_position` VALUES ('359', '200000003');
INSERT INTO `t_position` VALUES ('360', '200000003');
INSERT INTO `t_position` VALUES ('361', '200000003');
INSERT INTO `t_position` VALUES ('362', '200000003');
INSERT INTO `t_position` VALUES ('363', '200000003');
INSERT INTO `t_position` VALUES ('364', '200000003');
INSERT INTO `t_position` VALUES ('365', '200000003');
INSERT INTO `t_position` VALUES ('366', '200000003');
INSERT INTO `t_position` VALUES ('367', '200000003');
INSERT INTO `t_position` VALUES ('368', '200000003');
INSERT INTO `t_position` VALUES ('369', '200000003');
INSERT INTO `t_position` VALUES ('370', '200000003');
INSERT INTO `t_position` VALUES ('371', '200000003');
INSERT INTO `t_position` VALUES ('372', '200000003');
INSERT INTO `t_position` VALUES ('373', '200000003');
INSERT INTO `t_position` VALUES ('374', '200000003');
INSERT INTO `t_position` VALUES ('375', '200000003');
INSERT INTO `t_position` VALUES ('376', '200000003');
INSERT INTO `t_position` VALUES ('377', '200000003');
INSERT INTO `t_position` VALUES ('378', '200000003');
INSERT INTO `t_position` VALUES ('379', '200000003');
INSERT INTO `t_position` VALUES ('380', '200000003');
INSERT INTO `t_position` VALUES ('381', '200000003');
INSERT INTO `t_position` VALUES ('382', '200000003');

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
