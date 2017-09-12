/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50625
Source Host           : localhost:3306
Source Database       : archive

Target Server Type    : MYSQL
Target Server Version : 50625
File Encoding         : 65001

Date: 2017-08-03 16:17:44
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for t_archive
-- ----------------------------
DROP TABLE IF EXISTS `t_archive`;
CREATE TABLE `t_archive` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `idx` varchar(50) DEFAULT NULL COMMENT '序号',
  `manager` varchar(255) DEFAULT NULL COMMENT '负责人',
  `title` varchar(255) DEFAULT NULL COMMENT '题目',
  `pages` varchar(255) DEFAULT NULL COMMENT '页数',
  `number` varchar(100) DEFAULT NULL COMMENT '数量',
  `remark` varchar(255) DEFAULT NULL COMMENT '备注',
  `operateman` varchar(255) NOT NULL COMMENT '操作员',
  `operatetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '操作时间',
  `boxid` int(11) DEFAULT '0' COMMENT '盒id',
  `status` int(11) DEFAULT '0' COMMENT '0:在库，1：借出',
  `borrowid` int(11) DEFAULT '0' COMMENT '借阅人id',
  `lastborrowtime` datetime DEFAULT NULL COMMENT '最近借阅时间',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=123 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_archive
-- ----------------------------
INSERT INTO `t_archive` VALUES ('1', '1', '杭州市申遗办金向东', '北京市西湖文化遗址65552221', '312', '4535345345345345', null, 'admin', '2016-02-24 19:55:19', '7', '1', '77', null);
INSERT INTO `t_archive` VALUES ('2', '2', '杭州市申遗办金向东', '北京市西湖文化遗址65552222', '313', '4535345345345345', null, 'admin', '2016-02-24 19:55:19', '7', '1', '78', null);
INSERT INTO `t_archive` VALUES ('3', '3', '杭州市申遗办金向东', '北京市西湖文化遗址65552223', '314', '4535345345345345', null, 'admin', '2016-02-24 19:55:19', '7', '1', '79', '2017-05-19 15:31:04');
INSERT INTO `t_archive` VALUES ('4', '4', '杭州市申遗办金向东', '北京市西湖文化遗址65552224', '315', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('5', '5', '杭州市申遗办金向东', '北京市西湖文化遗址65552225', '316', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', '2017-05-02 15:31:10');
INSERT INTO `t_archive` VALUES ('6', '6', '杭州市申遗办金向东', '北京市西湖文化遗址65552226', '317', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '5', '1', '80', null);
INSERT INTO `t_archive` VALUES ('7', '7', '杭州市申遗办金向东', '北京市西湖文化遗址65552227', '318', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '5', '0', '0', null);
INSERT INTO `t_archive` VALUES ('8', '8', '杭州市申遗办金向东', '北京市西湖文化遗址65552228', '319', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', '2017-05-16 15:31:13');
INSERT INTO `t_archive` VALUES ('9', '9', '杭州市申遗办金向东', '北京市西湖文化遗址65552229', '320', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', '2017-05-16 15:31:22');
INSERT INTO `t_archive` VALUES ('10', '10', '杭州市申遗办金向东', '北京市西湖文化遗址65552230', '321', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', '2017-05-17 15:31:19');
INSERT INTO `t_archive` VALUES ('11', '11', '杭州市申遗办金向东', '北京市西湖文化遗址65552231', '322', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('12', '12', '杭州市申遗办金向东', '北京市西湖文化遗址65552232', '323', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('13', '13', '杭州市申遗办金向东', '北京市西湖文化遗址65552233', '324', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('14', '14', '杭州市申遗办金向东', '北京市西湖文化遗址65552234', '325', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '1', '81', null);
INSERT INTO `t_archive` VALUES ('15', '15', '杭州市申遗办金向东', '北京市西湖文化遗址65552235', '326', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('16', '16', '杭州市申遗办金向东', '北京市西湖文化遗址65552236', '327', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('17', '17', '杭州市申遗办金向东', '北京市西湖文化遗址65552237', '328', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('18', '18', '杭州市申遗办金向东', '北京市西湖文化遗址65552238', '329', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('19', '19', '杭州市申遗办金向东', '北京市西湖文化遗址65552239', '330', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('20', '20', '杭州市申遗办金向东', '北京市西湖文化遗址65552240', '331', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('21', '21', '杭州市申遗办金向东', '北京市西湖文化遗址65552241', '332', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '1', '83', null);
INSERT INTO `t_archive` VALUES ('22', '22', '杭州市申遗办金向东', '北京市西湖文化遗址65552242', '333', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('23', '23', '杭州市申遗办金向东', '北京市西湖文化遗址65552243', '334', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '4', '0', '0', null);
INSERT INTO `t_archive` VALUES ('24', '24', '杭州市申遗办金向东', '北京市西湖文化遗址65552244', '335', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '3', '0', '0', null);
INSERT INTO `t_archive` VALUES ('25', '25', '杭州市申遗办金向东', '北京市西湖文化遗址65552245', '336', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('26', '26', '杭州市申遗办金向东', '北京市西湖文化遗址65552246', '337', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('27', '27', '杭州市申遗办金向东', '北京市西湖文化遗址65552247', '338', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('28', '28', '杭州市申遗办金向东', '北京市西湖文化遗址65552248', '339', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('29', '29', '杭州市申遗办金向东', '北京市西湖文化遗址65552249', '340', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('30', '30', '杭州市申遗办金向东', '北京市西湖文化遗址65552250', '341', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('31', '31', '杭州市申遗办金向东', '北京市西湖文化遗址65552251', '342', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('32', '32', '杭州市申遗办金向东', '北京市西湖文化遗址65552252', '343', '4535345345345345', null, 'admin', '2016-02-24 19:55:20', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('33', '33', '杭州市申遗办金向东', '北京市西湖文化遗址65552253', '344', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('34', '34', '杭州市申遗办金向东', '北京市西湖文化遗址65552254', '345', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('35', '35', '杭州市申遗办金向东', '北京市西湖文化遗址65552255', '346', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('36', '36', '杭州市申遗办金向东', '北京市西湖文化遗址65552256', '347', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('37', '37', '杭州市申遗办金向东', '北京市西湖文化遗址65552257', '348', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('38', '38', '杭州市申遗办金向东', '北京市西湖文化遗址65552258', '349', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('39', '39', '杭州市申遗办金向东', '北京市西湖文化遗址65552259', '350', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('40', '40', '杭州市申遗办金向东', '北京市西湖文化遗址65552260', '351', '4535345345345345', null, 'admin', '2016-02-24 19:55:21', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('41', '1', '2', '3', '4', '5', '6', 'admin', '2017-05-08 13:28:03', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('42', '2', '3', '4', '5', '6', '7', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('43', '3', '4', '5', '6', '7', '8', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('44', '4', '5', '6', '7', '8', '9', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('45', '5', '6', '7', '8', '9', '10', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('46', '6', '7', '8', '9', '10', '11', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('47', '7', '8', '9', '10', '11', '12', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('48', '8', '9', '10', '11', '12', '13', 'admin', '2017-05-08 13:28:04', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('49', '9', '10', '11', '12', '13', '14', 'admin', '2017-05-08 13:28:04', '2', '0', '0', null);
INSERT INTO `t_archive` VALUES ('50', '10', '11', '12', '13', '14', '15', 'admin', '2017-05-08 13:28:04', '2', '0', '0', null);
INSERT INTO `t_archive` VALUES ('51', '7001', '7002', '7003', '4', '5', '6', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('52', '7002', '7003', '7004', '5', '6', '7', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('53', '7003', '7004', '7005', '6', '7', '8', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('54', '7004', '7005', '7006', '7', '8', '9', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('55', '7005', '7006', '7007', '8', '9', '10', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('56', '7006', '7007', '7008', '9', '10', '11', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('57', '7007', '7008', '7009', '10', '11', '12', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('58', '7008', '7009', '7010', '11', '12', '13', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('59', '7009', '7010', '7011', '12', '13', '14', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('60', '7010', '7011', '7012', '13', '14', '15', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('61', '7011', '7012', '7013', '14', '15', '16', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('62', '7012', '7013', '7014', '15', '16', '17', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('63', '7013', '7014', '7015', '16', '17', '18', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('64', '7014', '7015', '7016', '17', '18', '19', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('65', '7015', '7016', '7017', '18', '19', '20', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('66', '7016', '7017', '7018', '19', '20', '21', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('67', '7017', '7018', '7019', '20', '21', '22', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('68', '7018', '7019', '7020', '21', '22', '23', 'admin', '2017-05-19 15:45:45', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('69', '7019', '7020', '7021', '22', '23', '24', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('70', '7020', '7021', '7022', '23', '24', '25', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('71', '7021', '7022', '7023', '24', '25', '26', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('72', '7022', '7023', '7024', '25', '26', '27', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('73', '7023', '7024', '7025', '26', '27', '28', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('74', '7024', '7025', '7026', '27', '28', '29', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('75', '7025', '7026', '7027', '28', '29', '30', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('76', '7026', '7027', '7028', '29', '30', '31', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('77', '7027', '7028', '7029', '30', '31', '32', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('78', '7028', '7029', '7030', '31', '32', '33', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('79', '7029', '7030', '7031', '32', '33', '34', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('80', '7030', '7031', '7032', '33', '34', '35', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('81', '7031', '7032', '7033', '34', '35', '36', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('82', '7032', '7033', '7034', '35', '36', '37', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('83', '7033', '7034', '7035', '36', '37', '38', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('84', '7034', '7035', '7036', '37', '38', '39', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('85', '7035', '7036', '7037', '38', '39', '40', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('86', '7036', '7037', '7038', '39', '40', '41', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('87', '7037', '7038', '7039', '40', '41', '42', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('88', '7038', '7039', '7040', '41', '42', '43', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('89', '7039', '7040', '7041', '42', '43', '44', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('90', '7040', '7041', '7042', '43', '44', '45', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('91', '7041', '7042', '7043', '44', '45', '46', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('92', '7042', '7043', '7044', '45', '46', '47', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('93', '7043', '7044', '7045', '46', '47', '48', 'admin', '2017-05-19 15:45:46', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('94', '7044', '7045', '7046', '47', '48', '49', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('95', '7045', '7046', '7047', '48', '49', '50', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('96', '7046', '7047', '7048', '49', '50', '51', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('97', '7047', '7048', '7049', '50', '51', '52', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('98', '7048', '7049', '7050', '51', '52', '53', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('99', '7049', '7050', '7051', '52', '53', '54', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('100', '7050', '7051', '7052', '53', '54', '55', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('101', '7051', '7052', '7053', '54', '55', '56', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('102', '7052', '7053', '7054', '55', '56', '57', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('103', '7053', '7054', '7055', '56', '57', '58', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('104', '7054', '7055', '7056', '57', '58', '59', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('105', '7055', '7056', '7057', '58', '59', '60', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('106', '7056', '7057', '7058', '59', '60', '61', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('107', '7057', '7058', '7059', '60', '61', '62', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('108', '7058', '7059', '7060', '61', '62', '63', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('109', '7059', '7060', '7061', '62', '63', '64', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('110', '7060', '7061', '7062', '63', '64', '65', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('111', '7061', '7062', '7063', '64', '65', '66', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('112', '7062', '7063', '7064', '65', '66', '67', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('113', '7063', '7064', '7065', '66', '67', '68', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('114', '7064', '7065', '7066', '67', '68', '69', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('115', '7065', '7066', '7067', '68', '69', '70', 'admin', '2017-05-19 15:45:47', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('116', '7066', '7067', '7068', '69', '70', '71', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('117', '7067', '7068', '7069', '70', '71', '72', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('118', '7068', '7069', '7070', '71', '72', '73', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('119', '7069', '7070', '7071', '72', '73', '74', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('120', '7070', '7071', '7072', '73', '74', '75', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('121', '7071', '7072', '7073', '74', '75', '76', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);
INSERT INTO `t_archive` VALUES ('122', '7072', '7073', '7074', '75', '76', '77', 'admin', '2017-05-19 15:45:48', '0', '0', '0', null);

-- ----------------------------
-- Table structure for t_borrow
-- ----------------------------
DROP TABLE IF EXISTS `t_borrow`;
CREATE TABLE `t_borrow` (
  `borrowid` bigint(20) NOT NULL AUTO_INCREMENT,
  `archiveid` int(20) DEFAULT NULL COMMENT '档案id',
  `borrowerid` int(11) DEFAULT NULL COMMENT '借阅人id',
  `status` int(11) DEFAULT '0' COMMENT '0：在库1：借出',
  `createtime` timestamp NOT NULL DEFAULT '0000-00-00 00:00:00' ON UPDATE CURRENT_TIMESTAMP COMMENT '创建时间',
  `operatorid` int(11) DEFAULT NULL COMMENT '经办人id',
  `operatorname` varchar(255) DEFAULT NULL COMMENT '经办人',
  `remark` varchar(256) DEFAULT NULL COMMENT '备注',
  PRIMARY KEY (`borrowid`)
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_borrow
-- ----------------------------
INSERT INTO `t_borrow` VALUES ('47', '14', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('48', '20', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('49', '21', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('50', '22', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('51', '24', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('52', '1', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('53', '2', '3', '1', '2017-05-18 16:29:42', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('54', '3', '3', '1', '2017-05-18 16:29:43', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('55', '1', '0', '0', '2017-05-18 19:25:22', '0', null, null);
INSERT INTO `t_borrow` VALUES ('56', '2', '0', '0', '2017-05-18 19:25:22', '0', null, null);
INSERT INTO `t_borrow` VALUES ('57', '3', '0', '0', '2017-05-18 19:25:22', '0', null, null);
INSERT INTO `t_borrow` VALUES ('58', '14', '0', '0', '2017-05-18 19:25:23', '0', null, null);
INSERT INTO `t_borrow` VALUES ('59', '20', '0', '0', '2017-05-18 19:25:23', '0', null, null);
INSERT INTO `t_borrow` VALUES ('60', '21', '0', '0', '2017-05-18 19:25:23', '0', null, null);
INSERT INTO `t_borrow` VALUES ('61', '22', '0', '0', '2017-05-18 19:25:23', '0', null, null);
INSERT INTO `t_borrow` VALUES ('62', '24', '0', '0', '2017-05-18 19:25:23', '0', null, null);
INSERT INTO `t_borrow` VALUES ('63', '12', '3', '1', '2017-05-18 19:33:55', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('64', '20', '3', '1', '2017-05-18 19:33:55', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('65', '13', '3', '1', '2017-05-18 19:35:06', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('66', '14', '3', '1', '2017-05-18 19:45:36', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('67', '7', '3', '1', '2017-05-18 19:50:39', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('68', '3', '3', '1', '2017-05-19 10:45:45', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('69', '2', '3', '1', '2017-05-19 10:48:58', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('70', '2', '0', '0', '2017-05-19 13:41:30', '0', null, null);
INSERT INTO `t_borrow` VALUES ('71', '3', '0', '0', '2017-05-19 13:41:30', '0', null, null);
INSERT INTO `t_borrow` VALUES ('72', '12', '0', '0', '2017-05-19 13:41:30', '0', null, null);
INSERT INTO `t_borrow` VALUES ('73', '7', '0', '0', '2017-05-19 13:43:15', '0', null, null);
INSERT INTO `t_borrow` VALUES ('74', '13', '0', '0', '2017-05-19 13:43:15', '0', null, null);
INSERT INTO `t_borrow` VALUES ('75', '14', '0', '0', '2017-05-19 13:43:15', '0', null, null);
INSERT INTO `t_borrow` VALUES ('76', '20', '0', '0', '2017-05-19 13:43:15', '0', null, null);
INSERT INTO `t_borrow` VALUES ('77', '1', '3', '1', '2017-05-19 13:48:05', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('78', '2', '3', '1', '2017-05-19 13:48:05', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('79', '3', '3', '1', '2017-05-19 13:48:05', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('80', '6', '3', '1', '2017-05-19 13:48:05', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('81', '14', '3', '1', '2017-05-19 13:48:25', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('82', '20', '3', '1', '2017-05-19 13:48:25', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('83', '21', '3', '1', '2017-05-19 13:48:25', '1', 'admin', null);
INSERT INTO `t_borrow` VALUES ('84', '20', '0', '0', '2017-05-19 13:48:51', '0', null, null);

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
  `remark` varchar(256) DEFAULT NULL COMMENT '备注',
  `createtime` timestamp NULL DEFAULT NULL ON UPDATE CURRENT_TIMESTAMP COMMENT '创建时间',
  PRIMARY KEY (`borrowerid`)
) ENGINE=InnoDB AUTO_INCREMENT=154 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_borrower
-- ----------------------------
INSERT INTO `t_borrower` VALUES ('2', '234234', null, '啊', '23423', null, null, '男', null, null, '2017-05-17 10:24:27');
INSERT INTO `t_borrower` VALUES ('3', '330724198110131338', null, '金向东', '研发部', null, null, '男', null, null, '2017-05-17 10:34:31');
INSERT INTO `t_borrower` VALUES ('4', '是', null, '撒飞', '发撒旦', null, null, '男', null, null, '2017-05-17 11:04:31');
INSERT INTO `t_borrower` VALUES ('5', 'asdf', 'sdf ', 'asd f', 'sdf', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('6', 'asdf', 'asdfas', 'dfasdfasdf', 'asdfasfa', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('7', 'asdfa', 'asdfa', 'sdfa', 'sdfasf', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('8', 'asdfa', 'asdfasd', 'fasd', 'fasd', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('9', 'sdfsdf', 'sdfsdfs', 'dfa', 'fas', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('10', '7001', null, '5', '7002', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('11', '7002', null, '6', '7003', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('12', '7003', null, '7', '7004', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('13', '7004', null, '8', '7005', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('14', '7005', null, '9', '7006', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('15', '7006', null, '10', '7007', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('16', '7007', null, '11', '7008', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('17', '7008', null, '12', '7009', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('18', '7009', null, '13', '7010', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('19', '7010', null, '14', '7011', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('20', '7011', null, '15', '7012', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('21', '7012', null, '16', '7013', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('22', '7013', null, '17', '7014', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('23', '7014', null, '18', '7015', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('24', '7015', null, '19', '7016', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('25', '7016', null, '20', '7017', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('26', '7017', null, '21', '7018', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('27', '7018', null, '22', '7019', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('28', '7019', null, '23', '7020', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('29', '7020', null, '24', '7021', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('30', '7021', null, '25', '7022', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('31', '7022', null, '26', '7023', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('32', '7023', null, '27', '7024', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('33', '7024', null, '28', '7025', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('34', '7025', null, '29', '7026', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('35', '7026', null, '30', '7027', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('36', '7027', null, '31', '7028', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('37', '7028', null, '32', '7029', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('38', '7029', null, '33', '7030', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('39', '7030', null, '34', '7031', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('40', '7031', null, '35', '7032', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('41', '7032', null, '36', '7033', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('42', '7033', null, '37', '7034', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('43', '7034', null, '38', '7035', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('44', '7035', null, '39', '7036', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('45', '7036', null, '40', '7037', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('46', '7037', null, '41', '7038', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('47', '7038', null, '42', '7039', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('48', '7039', null, '43', '7040', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('49', '7040', null, '44', '7041', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('50', '7041', null, '45', '7042', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('51', '7042', null, '46', '7043', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('52', '7043', null, '47', '7044', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('53', '7044', null, '48', '7045', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('54', '7045', null, '49', '7046', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('55', '7046', null, '50', '7047', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('56', '7047', null, '51', '7048', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('57', '7048', null, '52', '7049', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('58', '7049', null, '53', '7050', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('59', '7050', null, '54', '7051', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('60', '7051', null, '55', '7052', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('61', '7052', null, '56', '7053', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('62', '7053', null, '57', '7054', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('63', '7054', null, '58', '7055', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('64', '7055', null, '59', '7056', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('65', '7056', null, '60', '7057', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('66', '7057', null, '61', '7058', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('67', '7058', null, '62', '7059', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('68', '7059', null, '63', '7060', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('69', '7060', null, '64', '7061', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('70', '7061', null, '65', '7062', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('71', '7062', null, '66', '7063', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('72', '7063', null, '67', '7064', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('73', '7064', null, '68', '7065', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('74', '7065', null, '69', '7066', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('75', '7066', null, '70', '7067', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('76', '7067', null, '71', '7068', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('77', '7068', null, '72', '7069', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('78', '7069', null, '73', '7070', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('79', '7070', null, '74', '7071', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('80', '7071', null, '75', '7072', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('81', '7072', null, '76', '7073', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('82', '8001', null, '8003', '2005', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('83', '8002', null, '8004', '2006', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('84', '8003', null, '8005', '2007', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('85', '8004', null, '8006', '2008', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('86', '8005', null, '8007', '2009', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('87', '8006', null, '8008', '2010', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('88', '8007', null, '8009', '2011', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('89', '8008', null, '8010', '2012', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('90', '8009', null, '8011', '2013', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('91', '8010', null, '8012', '2014', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('92', '8011', null, '8013', '2015', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('93', '8012', null, '8014', '2016', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('94', '8013', null, '8015', '2017', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('95', '8014', null, '8016', '2018', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('96', '8015', null, '8017', '2019', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('97', '8016', null, '8018', '2020', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('98', '8017', null, '8019', '2021', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('99', '8018', null, '8020', '2022', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('100', '8019', null, '8021', '2023', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('101', '8020', null, '8022', '2024', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('102', '8021', null, '8023', '2025', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('103', '8022', null, '8024', '2026', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('104', '8023', null, '8025', '2027', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('105', '8024', null, '8026', '2028', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('106', '8025', null, '8027', '2029', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('107', '8026', null, '8028', '2030', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('108', '8027', null, '8029', '2031', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('109', '8028', null, '8030', '2032', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('110', '8029', null, '8031', '2033', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('111', '8030', null, '8032', '2034', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('112', '8031', null, '8033', '2035', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('113', '8032', null, '8034', '2036', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('114', '8033', null, '8035', '2037', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('115', '8034', null, '8036', '2038', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('116', '8035', null, '8037', '2039', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('117', '8036', null, '8038', '2040', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('118', '8037', null, '8039', '2041', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('119', '8038', null, '8040', '2042', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('120', '8039', null, '8041', '2043', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('121', '8040', null, '8042', '2044', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('122', '8041', null, '8043', '2045', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('123', '8042', null, '8044', '2046', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('124', '8043', null, '8045', '2047', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('125', '8044', null, '8046', '2048', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('126', '8045', null, '8047', '2049', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('127', '8046', null, '8048', '2050', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('128', '8047', null, '8049', '2051', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('129', '8048', null, '8050', '2052', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('130', '8049', null, '8051', '2053', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('131', '8050', null, '8052', '2054', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('132', '8051', null, '8053', '2055', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('133', '8052', null, '8054', '2056', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('134', '8053', null, '8055', '2057', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('135', '8054', null, '8056', '2058', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('136', '8055', null, '8057', '2059', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('137', '8056', null, '8058', '2060', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('138', '8057', null, '8059', '2061', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('139', '8058', null, '8060', '2062', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('140', '8059', null, '8061', '2063', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('141', '8060', null, '8062', '2064', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('142', '8061', null, '8063', '2065', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('143', '8062', null, '8064', '2066', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('144', '8063', null, '8065', '2067', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('145', '8064', null, '8066', '2068', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('146', '8065', null, '8067', '2069', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('147', '8066', null, '8068', '2070', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('148', '8067', null, '8069', '2071', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('149', '8068', null, '8070', '2072', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('150', '8069', null, '8071', '2073', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('151', '8070', null, '8072', '2074', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('152', '8071', null, '8073', '2075', null, null, '男', null, null, null);
INSERT INTO `t_borrower` VALUES ('153', '8072', null, '8074', '2076', null, null, '男', null, null, null);

-- ----------------------------
-- Table structure for t_boxlabel
-- ----------------------------
DROP TABLE IF EXISTS `t_boxlabel`;
CREATE TABLE `t_boxlabel` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL COMMENT '盒标签名称',
  `rfid` varchar(100) NOT NULL COMMENT '标签id',
  `number` varchar(100) DEFAULT NULL COMMENT '盒标签编号',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_boxlabel
-- ----------------------------
INSERT INTO `t_boxlabel` VALUES ('1', '11', '11', '11111');
INSERT INTO `t_boxlabel` VALUES ('2', '22', '222', '222');
INSERT INTO `t_boxlabel` VALUES ('3', '3', '3', '3');
INSERT INTO `t_boxlabel` VALUES ('4', '是', '1', '1');
INSERT INTO `t_boxlabel` VALUES ('5', '5', '5', '5');
INSERT INTO `t_boxlabel` VALUES ('6', '6', '6', '6');
INSERT INTO `t_boxlabel` VALUES ('7', '7', '7', '7');
INSERT INTO `t_boxlabel` VALUES ('8', '盒001', 'h001', 'h001');

-- ----------------------------
-- Table structure for t_floorlabel
-- ----------------------------
DROP TABLE IF EXISTS `t_floorlabel`;
CREATE TABLE `t_floorlabel` (
  `id` int(8) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) DEFAULT NULL COMMENT '层标签名称',
  `rfid` varchar(255) NOT NULL COMMENT '标签内部唯一id',
  `number` varchar(100) DEFAULT NULL COMMENT '层编号',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of t_floorlabel
-- ----------------------------
INSERT INTO `t_floorlabel` VALUES ('1', '34534', '4534534', null);
INSERT INTO `t_floorlabel` VALUES ('2', '层002', '2222222222', '2222222222');
INSERT INTO `t_floorlabel` VALUES ('3', '层001', '11111111111', '11111111111');

-- ----------------------------
-- Table structure for t_inventory
-- ----------------------------
DROP TABLE IF EXISTS `t_inventory`;
CREATE TABLE `t_inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL COMMENT '盘点标题',
  `operateid` int(11) NOT NULL COMMENT '操作员id',
  `operatename` varchar(50) NOT NULL COMMENT '操作员名称',
  `operatetime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT '操作时间',
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
  `mid` int(11) NOT NULL COMMENT '主表t_inventory的主键id',
  `floorrfid` varchar(100) NOT NULL COMMENT '层标签表主键id',
  `boxrfid` varchar(100) DEFAULT NULL COMMENT '盒标签表id',
  `status` varchar(50) DEFAULT NULL COMMENT '盘点状态',
  `borrowstatus` varchar(50) DEFAULT NULL COMMENT '借阅状态',
  `borrowdate` varchar(50) DEFAULT NULL COMMENT '借阅时间',
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
INSERT INTO `t_position` VALUES ('222', '4534534');
INSERT INTO `t_position` VALUES ('33', '4534534');
INSERT INTO `t_position` VALUES ('1', '4534534');
INSERT INTO `t_position` VALUES ('1111', '4534534');
INSERT INTO `t_position` VALUES ('5', '4534534');
INSERT INTO `t_position` VALUES ('6', '4534534');
INSERT INTO `t_position` VALUES ('7', '2');

-- ----------------------------
-- Table structure for t_user
-- ----------------------------
DROP TABLE IF EXISTS `t_user`;
CREATE TABLE `t_user` (
  `userid` int(11) NOT NULL AUTO_INCREMENT COMMENT '主键',
  `username` varchar(45) NOT NULL COMMENT '用户名',
  `password` varchar(45) NOT NULL COMMENT '密码',
  `realname` varchar(45) DEFAULT NULL COMMENT '姓名',
  `sex` varchar(45) DEFAULT '男' COMMENT '性别',
  `phone` varchar(45) DEFAULT NULL COMMENT '手机',
  `age` int(2) DEFAULT '30' COMMENT '年龄',
  `roletype` varchar(45) DEFAULT NULL COMMENT '角色类型',
  `createtime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '创建时间',
  `createman` varchar(45) NOT NULL COMMENT '创建人',
  `modifytime` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP COMMENT '修改时间',
  `modifyman` varchar(45) NOT NULL COMMENT '修改人',
  `enable` smallint(2) NOT NULL DEFAULT '1' COMMENT '启用状态',
  `address` varchar(255) DEFAULT NULL COMMENT '地址',
  PRIMARY KEY (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='用户表';

-- ----------------------------
-- Records of t_user
-- ----------------------------
INSERT INTO `t_user` VALUES ('1', 'admin', '123456', 'admin', '女', '13757193476', '30', 'admin', '2016-01-16 13:16:31', 'admin', '2017-05-15 11:11:22', 'admin', '1', null);
INSERT INTO `t_user` VALUES ('2', 'ok', '123456', 'ok', '男', null, '30', 'user', '2017-05-15 11:11:41', 'admin', '2017-05-15 11:11:41', 'admin', '1', null);

-- ----------------------------
-- View structure for v_archive
-- ----------------------------
DROP VIEW IF EXISTS `v_archive`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_archive` AS select a.id , a.idx , a.manager , a.number ,a.pages, a.title , a.boxid,a.operateman,a.operatetime,a.remark, a.status , (case a.status when 0 then '在库' when 1 then '借出' else '未知֪' end) as statusname,
 b.name as boxname , b.rfid as boxrfid , b.number as boxnumber , d.name as floorname , c.floorrfid  , CONCAT_WS(',', d.name , b.name) as position
from t_archive a left JOIN t_boxlabel b on a.boxid = b.id 
 left JOIN t_position c on b.rfid = c.boxrfid 
left JOIN t_floorlabel d on c.floorrfid = d.rfid ;

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
on e.borrowerid = f.borrowerid ;

-- ----------------------------
-- View structure for v_box
-- ----------------------------
DROP VIEW IF EXISTS `v_box`;
CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER  VIEW `v_box` AS select a.id , a.name,a.number , a.rfid , b.floorrfid , c.name as floorname from t_boxlabel a LEFT JOIN t_position b on a.rfid= b.boxrfid LEFT JOIN t_floorlabel c on b.floorrfid= c.rfid ;
