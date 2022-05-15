

	create table IF NOT EXISTS `Movies` (
		`id_movie` BIGINT NOT NULL AUTO_INCREMENT, 
		`name` VARCHAR(255) NOT NULL, 
		`ds_movie` VARCHAR(255) NOT NULL, 
		`rating` VARCHAR(3) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`start_time` DATETIME NOT NULL, 
		`end_time` DATETIME NOT NULL, 
		`id_status` INT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie`)
	);

	create table IF NOT EXISTS `MovieAttachments` (
		`id_movie_attachment` BIGINT NOT NULL AUTO_INCREMENT, 
		`ds_url` VARCHAR(255) NOT NULL, 
		`id_attachment_type` INT NOT NULL, 
		`MovieId` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie_attachment`)
	);

	create table IF NOT EXISTS `MovieSessions` (
		`id_movie_session` BIGINT NOT NULL AUTO_INCREMENT, 
		`amount` NUMERIC(10, 2) NULL, 
		`id_status` INT NOT NULL, 
		`id_session_type` INT NOT NULL, 
		`MovieId` BIGINT NOT NULL, 
		`id_session` INT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie_session`)
	);

	create table IF NOT EXISTS `Users` (
		`id_user` BIGINT NOT NULL AUTO_INCREMENT, 
		`name` VARCHAR(255) NOT NULL, 
		`email` VARCHAR(255) NOT NULL, 
		`password` VARCHAR(255) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`id_user_type` INT NOT NULL, 
		`id_status` INT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_user`)
	);

	create table IF NOT EXISTS `Transactions` (
		`id_transaction` BIGINT NOT NULL AUTO_INCREMENT, 
		`created_at` DATETIME NOT NULL, 
		`id_transaction_status` INT NOT NULL, 
		`MovieSessionId` BIGINT NOT NULL, 
		`UserId` BIGINT NOT NULL, 
		`CardId` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_transaction`)
	);

	create table IF NOT EXISTS `Cards` (
		`id_card` BIGINT NOT NULL AUTO_INCREMENT, 
		`holder_name` VARCHAR(255) NOT NULL, 
		`card_number` VARCHAR(16) NOT NULL, 
		`security_code` VARCHAR(3) NOT NULL, 
		`expiration_date` DATETIME NOT NULL, 
		`ACTIVITYSTATUS` INT NOT NULL, 
		`UserId` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_card`)
	);

	create table IF NOT EXISTS `Itens` (
		`id_item` BIGINT NOT NULL AUTO_INCREMENT, 
		`amount` NUMERIC(10, 2) NOT NULL, 
		`name` VARCHAR(255) NOT NULL, 
		`seat` VARCHAR(3) NOT NULL, 
		`TransactionId` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_item`)
	);

	create table IF NOT EXISTS `Sessions` (
		`id_session` INT NOT NULL AUTO_INCREMENT, 
		`session_hour` VARCHAR(8) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`id_status` INT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_session`)
	);

	create table IF NOT EXISTS `MovieCategories` (
		`id_movie_category` BIGINT NOT NULL AUTO_INCREMENT, 
		`CATEGORY` INT NOT NULL, 
		`id_movie` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie_category`)
	);



ALTER TABLE `MovieAttachments` ADD CONSTRAINT `FK_MovieAttachments_Movie` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`id_movie`);
CREATE INDEX IMovieAttachments_Movie ON `MovieAttachments` (`MovieId`);
ALTER TABLE `MovieSessions` ADD CONSTRAINT `FK_MovieSessions_Movie` FOREIGN KEY (`MovieId`) REFERENCES `Movies` (`id_movie`);
CREATE INDEX IMovieSessions_Movie ON `MovieSessions` (`MovieId`);
ALTER TABLE `MovieSessions` ADD CONSTRAINT `FK_MovieSessions_Session` FOREIGN KEY (`id_session`) REFERENCES `Sessions` (`id_session`);
CREATE INDEX IMovieSessions_Session ON `MovieSessions` (`id_session`);
ALTER TABLE `Transactions` ADD CONSTRAINT `FK_Transactions_MovieSession` FOREIGN KEY (`MovieSessionId`) REFERENCES `MovieSessions` (`id_movie_session`);
CREATE INDEX ITransactions_MovieSession ON `Transactions` (`MovieSessionId`);
ALTER TABLE `Transactions` ADD CONSTRAINT `FK_Transactions_User` FOREIGN KEY (`UserId`) REFERENCES `Users` (`id_user`);
CREATE INDEX ITransactions_User ON `Transactions` (`UserId`);
ALTER TABLE `Transactions` ADD CONSTRAINT `FK_Transactions_Card` FOREIGN KEY (`CardId`) REFERENCES `Cards` (`id_card`);
CREATE INDEX ITransactions_Card ON `Transactions` (`CardId`);
ALTER TABLE `Cards` ADD CONSTRAINT `FK_Cards_User` FOREIGN KEY (`UserId`) REFERENCES `Users` (`id_user`);
CREATE INDEX ICards_User ON `Cards` (`UserId`);
ALTER TABLE `Itens` ADD CONSTRAINT `FK_Itens_Transaction` FOREIGN KEY (`TransactionId`) REFERENCES `Transactions` (`id_transaction`);
CREATE INDEX IItens_Transaction ON `Itens` (`TransactionId`);
ALTER TABLE `MovieCategories` ADD CONSTRAINT `FK_MovieCategories_Movie` FOREIGN KEY (`id_movie`) REFERENCES `Movies` (`id_movie`);
CREATE INDEX IMovieCategories_Movie ON `MovieCategories` (`id_movie`);

-- <#keep(end)#><#/keep(end)#>