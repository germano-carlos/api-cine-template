

	create table IF NOT EXISTS `Movies` (
		`id_movie` BIGINT NOT NULL AUTO_INCREMENT, 
		`name` VARCHAR(255) NOT NULL, 
		`ds_movie` VARCHAR(255) NOT NULL, 
		`rating` VARCHAR(3) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`start_time` DATETIME NOT NULL, 
		`end_time` DATETIME NOT NULL, 
		`id_status` INT NOT NULL, 
		`id_movie_category` INT NOT NULL, 
		`id_movie_session` BIGINT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie`)
	);

	create table IF NOT EXISTS `MovieAttachments` (
		`id_movie_attachment` BIGINT NOT NULL AUTO_INCREMENT, 
		`ds_url` VARCHAR(255) NOT NULL, 
		`id_attachment_type` INT NOT NULL, 
		`id_movie` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie_attachment`)
	);

	create table IF NOT EXISTS `MovieSessions` (
		`id_movie_session` BIGINT NOT NULL AUTO_INCREMENT, 
		`amount` NUMERIC(10, 2) NULL, 
		`id_status` INT NOT NULL, 
		`id_session_type` INT NOT NULL, 
		`id_transaction` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_movie_session`)
	);

	create table IF NOT EXISTS `Users` (
		`id_user` BIGINT NOT NULL AUTO_INCREMENT, 
		`name` VARCHAR(255) NOT NULL, 
		`email` VARCHAR(255) NOT NULL, 
		`password` VARCHAR(255) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`id_status` INT NOT NULL, 
		`id_user_type` INT NOT NULL, 
		`id_transaction` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_user`)
	);

	create table IF NOT EXISTS `Transactions` (
		`id_transaction` BIGINT NOT NULL AUTO_INCREMENT, 
		`created_at` DATETIME NOT NULL, 
		`id_transaction_status` INT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_transaction`)
	);

	create table IF NOT EXISTS `Cards` (
		`id_card` BIGINT NOT NULL AUTO_INCREMENT, 
		`holder_name` VARCHAR(255) NOT NULL, 
		`card_number` VARCHAR(16) NOT NULL, 
		`security_code` VARCHAR(3) NOT NULL, 
		`expiration_date` DATETIME NOT NULL, 
		`id_user` BIGINT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_card`)
	);

	create table IF NOT EXISTS `Itens` (
		`id_item` BIGINT NOT NULL AUTO_INCREMENT, 
		`amount` NUMERIC(10, 2) NOT NULL, 
		`name` VARCHAR(255) NOT NULL, 
		`id_transaction` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_item`)
	);

	create table IF NOT EXISTS `Sessions` (
		`id_session` INT NOT NULL AUTO_INCREMENT, 
		`session_hour` VARCHAR(8) NOT NULL, 
		`created_at` DATETIME NOT NULL, 
		`id_status` INT NOT NULL, 
		`id_movie_session` BIGINT NOT NULL, 
		PRIMARY KEY CLUSTERED (
			`id_session`)
	);



ALTER TABLE `Movies` ADD CONSTRAINT `FK_Movies_MovieSession` FOREIGN KEY (`id_movie_session`) REFERENCES `MovieSessions` (`id_movie_session`);
CREATE INDEX IMovies_MovieSession ON `Movies` (`id_movie_session`);
ALTER TABLE `MovieAttachments` ADD CONSTRAINT `FK_MovieAttachments_Movie` FOREIGN KEY (`id_movie`) REFERENCES `Movies` (`id_movie`);
CREATE INDEX IMovieAttachments_Movie ON `MovieAttachments` (`id_movie`);
ALTER TABLE `MovieSessions` ADD CONSTRAINT `FK_MovieSessions_Transaction` FOREIGN KEY (`id_transaction`) REFERENCES `Transactions` (`id_transaction`);
CREATE INDEX IMovieSessions_Transaction ON `MovieSessions` (`id_transaction`);
ALTER TABLE `Users` ADD CONSTRAINT `FK_Users_Transaction` FOREIGN KEY (`id_transaction`) REFERENCES `Transactions` (`id_transaction`);
CREATE INDEX IUsers_Transaction ON `Users` (`id_transaction`);
ALTER TABLE `Cards` ADD CONSTRAINT `FK_Cards_User` FOREIGN KEY (`id_user`) REFERENCES `Users` (`id_user`);
CREATE INDEX ICards_User ON `Cards` (`id_user`);
ALTER TABLE `Itens` ADD CONSTRAINT `FK_Itens_Transaction` FOREIGN KEY (`id_transaction`) REFERENCES `Transactions` (`id_transaction`);
CREATE INDEX IItens_Transaction ON `Itens` (`id_transaction`);
ALTER TABLE `Sessions` ADD CONSTRAINT `FK_Sessions_MovieSession` FOREIGN KEY (`id_movie_session`) REFERENCES `MovieSessions` (`id_movie_session`);
CREATE INDEX ISessions_MovieSession ON `Sessions` (`id_movie_session`);

-- <#keep(end)#><#/keep(end)#>