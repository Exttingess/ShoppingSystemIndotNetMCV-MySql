/*
 Navicat Premium Data Transfer

 Source Server         : MySQL
 Source Server Type    : MySQL
 Source Server Version : 80017
 Source Host           : 127.0.0.1:3306
 Source Schema         : shops

 Target Server Type    : MySQL
 Target Server Version : 80017
 File Encoding         : 65001

 Date: 01/08/2020 10:18:13
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for products
-- ----------------------------
DROP TABLE IF EXISTS `products`;
CREATE TABLE `products`  (
  `Id` int(11) NOT NULL,
  `Description` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `ImageUrl` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `Price` decimal(10, 2) DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of products
-- ----------------------------
INSERT INTO `products` VALUES (1, '智能电视，安卓10，wifi联网，点播。。。。', '/images/1.jpg', '电视', 1500.00);
INSERT INTO `products` VALUES (2, '卖家销售并发货的商品，由平台卖家提供发票和相应的售后服务。请您放心购买！\r\n注：因厂家会在没有任何提前通知的情况下更改产品包装、产地或者一些附件，本司不能确保客户收到的货物与商城图片、产地、附件', '/images/2.jpg', '智能手表', 1000.00);
INSERT INTO `products` VALUES (3, '荣耀智能，自拍，游戏，麒麟1020，8+256，IP68防水，智能手机', '/images/3.jpg', '手机', 2000.00);
INSERT INTO `products` VALUES (4, '雨伞，青年良品，时尚，情侣，德国进口精钢骨架', '/images/4.jpg', '雨伞', 25.00);
INSERT INTO `products` VALUES (5, '军规级品质，家用，野餐，超划算', '/images/5.jpg', '刀具套装', 50.00);
INSERT INTO `products` VALUES (6, '儿童卡通一次性使用医用口罩防尘防病菌透气中小学生小孩防护口罩 ', '/images/6.jpg', '儿童口罩', 13.00);
INSERT INTO `products` VALUES (7, '小碎花波点吊带雪纺连衣裙夏款小清新中长款显瘦很仙的内搭打底裙 ', '/images/7.jpg', '长裙', 160.00);
INSERT INTO `products` VALUES (8, '拖鞋，情侣，时尚，有内涵，居家必备，30包换', '/images/8.jpg', '棉拖鞋', 16.00);
INSERT INTO `products` VALUES (9, '人本秋季厚底帆布鞋韩版低帮增高学生百搭小白鞋松糕板鞋黑色女鞋 ，商品参与了公益宝贝计划，卖家承诺每笔成交将为守护民族英雄的晚年捐赠0.1%。该商品已累积捐赠251笔', '/images/9.jpg', '帆布鞋', 55.00);
INSERT INTO `products` VALUES (10, '联想ThinkPad T490 英特尔十代酷睿 IPS 1080高清四核高性能高端专业商务官方正品IBM笔记本电脑T470PT480 ', '/images/10.jpg', '笔记本电脑', 8000.00);

-- ----------------------------
-- Table structure for register
-- ----------------------------
DROP TABLE IF EXISTS `register`;
CREATE TABLE `register`  (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `passwd` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `sum` decimal(20, 0) DEFAULT 1000,
  `remark` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT 'customer',
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 11000 CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of register
-- ----------------------------
INSERT INTO `register` VALUES (1, '0', '0', 0, 'test');
INSERT INTO `register` VALUES (2, '12353453', '12eqad3hh23', 1000, 'customer');
INSERT INTO `register` VALUES (3, '123455', '423rewr3vwcc', 1000, 'customer');
INSERT INTO `register` VALUES (4, '3', '2224423r4r34f', 1000, 'customer');
INSERT INTO `register` VALUES (5, '1115', '2c3r2cr2cctct', 1950, 'customer');
INSERT INTO `register` VALUES (6, '0', '423423434f34f', 1000, 'customer');
INSERT INTO `register` VALUES (7, '333', '310dcbbf4cce62f762a2aaa148d556bd', 8873, 'customer');
INSERT INTO `register` VALUES (8, '123', '202cb962ac59075b964b07152d234b70', 1130, 'customer');
INSERT INTO `register` VALUES (9, '222', 'bcbe3365e6ac95ea2c0343a2395834dd', 1000, 'customer');
INSERT INTO `register` VALUES (11000, 'admin', '21232f297a57a5a743894a0e4a801fc3', 1000, 'customer');

-- ----------------------------
-- Table structure for shopping
-- ----------------------------
DROP TABLE IF EXISTS `shopping`;
CREATE TABLE `shopping`  (
  `id` int(11) NOT NULL,
  `user` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `cost` decimal(10, 2) DEFAULT NULL,
  `address` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT '山东省青岛市黄岛区滨海学院',
  `accountcode` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `accountdate` datetime(0) DEFAULT NULL,
  `execute` int(255) DEFAULT 1,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of shopping
-- ----------------------------
INSERT INTO `shopping` VALUES (2234, '677', 100.00, '山东省青岛市黄岛区滨海学院', 'x6365464', '2020-06-18 08:58:22', 1);
INSERT INTO `shopping` VALUES (2731, '123', 26.00, '山东省青岛市黄岛区滨海学院', 'x862731', '2020-06-30 11:20:19', 1);
INSERT INTO `shopping` VALUES (5383, '123', 1000.00, '山东省青岛市黄岛区滨海学院', 'x865383', '2020-07-02 10:36:33', 1);
INSERT INTO `shopping` VALUES (6496, '123', 50.00, '山东省青岛市黄岛区滨海学院', 'x8908765', '2020-06-18 12:40:10', 1);
INSERT INTO `shopping` VALUES (7053, '123', 25.00, '山东省青岛市黄岛区滨海学院', 'x867053', '2020-06-29 15:28:34', 1);
INSERT INTO `shopping` VALUES (7808, '123', 39.00, '山东省青岛市黄岛区滨海学院', 'x867808', '2020-06-30 15:31:11', 1);
INSERT INTO `shopping` VALUES (7970, '123', 2000.00, '山东省青岛市黄岛区滨海学院', 'x867970', '2020-06-30 11:26:28', 1);

-- ----------------------------
-- Table structure for shoppingbuy
-- ----------------------------
DROP TABLE IF EXISTS `shoppingbuy`;
CREATE TABLE `shoppingbuy`  (
  `id` int(11) NOT NULL,
  `user` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `product_id` varchar(255) CHARACTER SET utf8 COLLATE utf8_general_ci DEFAULT NULL,
  `num` int(11) DEFAULT NULL,
  `date` datetime(0) DEFAULT NULL,
  PRIMARY KEY (`id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = utf8 COLLATE = utf8_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of shoppingbuy
-- ----------------------------
INSERT INTO `shoppingbuy` VALUES (32, '123', '3', 1, '2020-06-18 08:54:17');

-- ----------------------------
-- View structure for vv
-- ----------------------------
DROP VIEW IF EXISTS `vv`;
CREATE ALGORITHM = UNDEFINED DEFINER = `root`@`localhost` SQL SECURITY DEFINER VIEW `vv` AS select `products`.`Id` AS `id`,`register`.`name` AS `name`,`products`.`Price` AS `Price` from (`register` join `products`);

SET FOREIGN_KEY_CHECKS = 1;
