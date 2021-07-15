-- CREATE table Theories(
--   id INT NOT NULL AUTO_INCREMENT,
--   body VARCHAR(255) NOT NULL,
--   result VARCHAR(255),
--   imgUrl VARCHAR(255),
--   PRIMARY KEY (id)
-- )


CREATE table Recipes(
    id INT NOT NULL primary key AUTO_INCREMENT comment 'primary key',
 createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    creatorId VARCHAR(255) NOT NULL,
    title VARCHAR(255),
    description  VARCHAR(255),
    imgUrl VARCHAR(255),
    steps VARCHAR(255),
    ingredients VARCHAR(255)
) default charset utf8 comment '';

SELECT * FROM Recipes