

CREATE TABLE IF NOT EXISTS `race`.`user` (
  `userID` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(16) NOT NULL,
  `email` VARCHAR(255) NULL,
  `password` VARCHAR(32) NOT NULL,
  `cash` INT NOT NULL,
  `create_time` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`userID`));

CREATE TABLE IF NOT EXISTS `race`.`history` (
  `idhistory` INT NOT NULL AUTO_INCREMENT,
  `win` INT NOT NULL,
  `description` VARCHAR(45) NOT NULL,
  `user_userID` INT NOT NULL,
  PRIMARY KEY (`idhistory`),
  INDEX `fk_history_user_idx` (`user_userID` ASC),
  CONSTRAINT `fk_history_user`
    FOREIGN KEY (`user_userID`)
    REFERENCES `mydb`.`user` (`userID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;