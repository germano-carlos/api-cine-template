CREATE DATABASE  IF NOT EXISTS `movie5`;
USE `movie5`;

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `id_user` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `created_at` datetime NOT NULL,
  `id_user_type` int NOT NULL,
  `id_status` int NOT NULL,
  PRIMARY KEY (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `cards`;
CREATE TABLE `cards` (
  `id_card` bigint NOT NULL AUTO_INCREMENT,
  `holder_name` varchar(255) NOT NULL,
  `card_number` varchar(16) NOT NULL,
  `security_code` varchar(3) NOT NULL,
  `expiration_date` datetime NOT NULL,
  `UserId` bigint NOT NULL,
  `ACTIVITYSTATUS` int NOT NULL,
  PRIMARY KEY (`id_card`),
  KEY `ICards_User` (`UserId`),
  CONSTRAINT `FK_Cards_User` FOREIGN KEY (`UserId`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=26 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `movies`;
CREATE TABLE `movies` (
  `id_movie` bigint NOT NULL AUTO_INCREMENT,
  `name` varchar(255) NOT NULL,
  `ds_movie` varchar(255) NOT NULL,
  `rating` varchar(4) NOT NULL,
  `created_at` datetime NOT NULL,
  `start_time` datetime NOT NULL,
  `end_time` datetime NOT NULL,
  `id_status` int NOT NULL,
  PRIMARY KEY (`id_movie`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `sessions`;
CREATE TABLE `sessions` (
  `id_session` int NOT NULL AUTO_INCREMENT,
  `session_hour` varchar(8) NOT NULL,
  `created_at` datetime NOT NULL,
  `id_status` int NOT NULL,
  PRIMARY KEY (`id_session`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `moviesessions`;
CREATE TABLE `moviesessions` (
  `id_movie_session` bigint NOT NULL AUTO_INCREMENT,
  `amount` decimal(10,2) DEFAULT NULL,
  `id_status` int NOT NULL,
  `id_session_type` int NOT NULL,
  `MovieId` bigint NOT NULL,
  `id_session` int NOT NULL,
  PRIMARY KEY (`id_movie_session`),
  KEY `IMovieSessions_Movie` (`MovieId`),
  KEY `IMovieSessions_Session` (`id_session`),
  CONSTRAINT `FK_MovieSessions_Movie` FOREIGN KEY (`MovieId`) REFERENCES `movies` (`id_movie`),
  CONSTRAINT `FK_MovieSessions_Session` FOREIGN KEY (`id_session`) REFERENCES `sessions` (`id_session`)
) ENGINE=InnoDB AUTO_INCREMENT=33 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `movieattachments`;
CREATE TABLE `movieattachments` (
  `id_movie_attachment` bigint NOT NULL AUTO_INCREMENT,
  `ds_url` varchar(255) NOT NULL,
  `id_attachment_type` int NOT NULL,
  `MovieId` bigint NOT NULL,
  PRIMARY KEY (`id_movie_attachment`),
  KEY `IMovieAttachments_Movie` (`MovieId`),
  CONSTRAINT `FK_MovieAttachments_Movie` FOREIGN KEY (`MovieId`) REFERENCES `movies` (`id_movie`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `moviecategories`;
CREATE TABLE `moviecategories` (
  `id_movie_category` bigint NOT NULL AUTO_INCREMENT,
  `CATEGORY` int NOT NULL,
  `id_movie` bigint NOT NULL,
  PRIMARY KEY (`id_movie_category`),
  KEY `IMovieCategories_Movie` (`id_movie`),
  CONSTRAINT `FK_MovieCategories_Movie` FOREIGN KEY (`id_movie`) REFERENCES `movies` (`id_movie`)
) ENGINE=InnoDB AUTO_INCREMENT=52 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `transactions`;
CREATE TABLE `transactions` (
  `id_transaction` bigint NOT NULL AUTO_INCREMENT,
  `created_at` datetime NOT NULL,
  `id_transaction_status` int NOT NULL,
  `MovieSessionId` bigint NOT NULL,
  `UserId` bigint NOT NULL,
  `CardId` bigint NOT NULL,
  PRIMARY KEY (`id_transaction`),
  KEY `ITransactions_MovieSession` (`MovieSessionId`),
  KEY `ITransactions_User` (`UserId`),
  KEY `ITransactions_Card` (`CardId`),
  CONSTRAINT `FK_Transactions_Card` FOREIGN KEY (`CardId`) REFERENCES `cards` (`id_card`),
  CONSTRAINT `FK_Transactions_MovieSession` FOREIGN KEY (`MovieSessionId`) REFERENCES `moviesessions` (`id_movie_session`),
  CONSTRAINT `FK_Transactions_User` FOREIGN KEY (`UserId`) REFERENCES `users` (`id_user`)
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `itens`;
CREATE TABLE `itens` (
  `id_item` bigint NOT NULL AUTO_INCREMENT,
  `amount` decimal(10,2) NOT NULL,
  `name` varchar(255) NOT NULL,
  `seat` varchar(3) NOT NULL,
  `TransactionId` bigint NOT NULL,
  PRIMARY KEY (`id_item`),
  KEY `IItens_Transaction` (`TransactionId`),
  CONSTRAINT `FK_Itens_Transaction` FOREIGN KEY (`TransactionId`) REFERENCES `transactions` (`id_transaction`)
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

DROP TABLE IF EXISTS `logs`;
CREATE TABLE `logs` (
  `Id` bigint NOT NULL AUTO_INCREMENT,
  `descricao` varchar(1000) NOT NULL,
  `created_at` datetime NOT NULL,
  `stack_trace` varchar(0) DEFAULT NULL,
  `TYPELOG` int NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;


INSERT INTO `users` VALUES (1,'Nome Atualizado','carlos@enterprise.com.br','Senha Segura','2022-05-24 23:52:35',2,1),(2,'Nome Atualizado','carlos@enterprise.com.br','Senha Segura','2022-05-24 23:54:06',2,1),(3,'Nome Atualizado','carlos@enterprise.com.br','Senha Segura','2022-05-24 23:56:31',2,1),(4,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-24 23:57:31',2,1),(5,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-24 23:58:47',2,1),(6,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:00:22',2,1),(7,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:00:43',2,1),(8,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:01:44',2,1),(9,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:02:30',2,1),(10,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:03:42',2,1),(11,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:04:20',2,1),(12,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:04:42',2,1),(13,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:06:49',2,1),(14,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:15:58',2,1),(15,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:34:05',2,1),(16,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:35:54',2,2),(17,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:12',2,1),(18,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:13',2,1),(19,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:13',2,1),(20,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:13',2,2),(21,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:29',2,1),(22,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:38:29',2,2),(23,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:02',2,1),(24,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:02',2,2),(25,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:11',2,1),(26,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:11',2,1),(27,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:11',2,2),(28,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 00:39:11',2,1),(29,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:18:12',2,1),(30,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:18:12',2,2),(31,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:22:54',2,1),(32,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:22:54',2,2),(33,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:36:00',2,1),(34,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:36:01',2,2),(35,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:19',2,1),(36,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:20',2,1),(37,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:20',2,2),(38,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:20',2,1),(39,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:30',2,1),(40,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 01:38:30',2,2),(41,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:18:11',2,1),(42,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:18:20',2,1),(43,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:19:14',2,1),(44,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:19:15',2,1),(45,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:20:42',2,1),(46,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:20:43',2,1),(47,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:21:25',2,1),(48,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:21:26',2,1),(49,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:21:26',2,2),(50,'Carlos Germano Avelar Carvalho','carlos@enterprise.com.br','batatinha1234','2022-05-25 02:21:26',2,1);
INSERT INTO `cards` VALUES (1,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',4,1),(2,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',5,1),(3,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',6,1),(4,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',7,1),(5,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',8,1),(6,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',9,1),(7,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',10,1),(8,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',11,1),(9,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',12,1),(10,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',13,1),(11,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',14,2),(12,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',17,1),(13,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',18,2),(14,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',25,1),(15,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',28,2),(16,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',35,1),(17,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',38,2),(18,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',41,1),(19,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',42,2),(20,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',43,1),(21,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',44,2),(22,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',45,1),(23,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',46,2),(24,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',47,1),(25,'CARLOS G A CARVALHO','5117659862365698','029','2029-06-30 00:00:00',50,2);
INSERT INTO `movies` VALUES (28,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:12:12','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(29,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:19:31','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(30,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:20:50','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(31,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:23:35','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(32,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:24:08','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(33,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:24:17','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(34,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:37:50','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(35,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-24 23:37:51','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(36,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:04:20','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(37,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:04:21','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(38,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:38:12','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(39,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:38:13','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(40,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:39:11','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(41,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 00:39:11','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(42,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 01:38:19','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(43,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 01:38:20','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(44,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:17:31','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(45,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:17:59','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(46,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:19:14','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(47,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:19:15','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(48,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:20:42','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(49,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:20:43','2022-06-01 00:00:00','2022-06-15 23:59:59',1),(50,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:21:25','2022-06-01 00:00:00','2022-06-15 23:59:59',2),(51,'Charlinhos, o Guerreiro Trovão','Esta é a criação de um filme teste','10.0','2022-05-25 02:21:26','2022-06-01 00:00:00','2022-06-15 23:59:59',1);
INSERT INTO `sessions` VALUES (1,'10:00','2022-05-25 00:50:37',1);
INSERT INTO `moviesessions` VALUES (7,10.00,1,1,28,1),(9,10.00,1,1,30,1),(10,30.00,1,1,28,1),(11,30.00,1,1,28,1),(12,30.00,1,1,28,1),(13,30.00,1,1,28,1),(14,30.00,1,1,28,1),(15,30.00,1,1,28,1),(16,30.00,1,1,28,1),(17,30.00,2,1,28,1),(18,30.00,1,1,28,1),(19,30.00,2,1,28,1),(20,30.00,2,1,28,1),(21,30.00,1,1,28,1),(22,30.00,2,1,28,1),(23,30.00,1,1,28,1),(24,30.00,2,1,28,1),(25,30.00,1,1,28,1),(26,30.00,2,1,28,1),(27,30.00,1,1,28,1),(28,30.00,2,1,28,1),(29,30.00,1,1,28,1),(30,30.00,2,1,28,1),(31,30.00,1,1,28,1),(32,30.00,2,1,28,1);
INSERT INTO `moviecategories` VALUES (28,1,28),(29,1,29),(30,1,30),(31,1,31),(32,1,32),(33,1,33),(34,1,34),(35,1,35),(36,1,36),(37,1,37),(38,1,38),(39,1,39),(40,1,40),(41,1,41),(42,1,42),(43,1,43),(44,1,44),(45,1,45),(46,1,46),(47,1,47),(48,1,48),(49,1,49),(50,1,50),(51,1,51);
INSERT INTO `transactions` VALUES (1,'2022-05-25 01:55:51',4,7,5,2),(2,'2022-05-25 01:57:32',4,7,5,2),(3,'2022-05-25 02:00:25',4,7,5,2),(4,'2022-05-25 02:01:37',4,7,5,2),(5,'2022-05-25 02:08:19',4,7,5,2),(6,'2022-05-25 02:08:33',4,7,5,2),(7,'2022-05-25 02:08:53',4,7,5,2),(8,'2022-05-25 02:10:33',4,7,5,2),(9,'2022-05-25 02:11:05',4,7,5,2),(10,'2022-05-25 02:11:22',4,7,5,2),(11,'2022-05-25 02:12:22',4,7,5,2),(12,'2022-05-25 02:13:04',4,7,5,2),(13,'2022-05-25 02:14:13',4,7,5,2),(14,'2022-05-25 02:17:01',4,7,5,2),(15,'2022-05-25 02:17:24',4,7,5,2),(16,'2022-05-25 02:19:15',4,7,5,2),(17,'2022-05-25 02:20:43',4,7,5,2),(18,'2022-05-25 02:21:26',4,7,5,2);
INSERT INTO `itens` VALUES (1,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',1),(2,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',1),(3,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',2),(4,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',2),(5,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',3),(6,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',3),(7,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',4),(8,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',4),(9,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',5),(10,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',5),(11,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',6),(12,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',6),(13,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',7),(14,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',7),(15,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',8),(16,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',8),(17,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',9),(18,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',9),(19,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',10),(20,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',10),(21,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',11),(22,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',11),(23,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',12),(24,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',12),(25,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',13),(26,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',13),(27,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',14),(28,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',14),(29,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',15),(30,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',15),(31,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',16),(32,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',16),(33,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',17),(34,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',17),(35,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H7',18),(36,10.00,'Ingresso Hotwheels Pista Tubarão (MEIA)','H8',18);