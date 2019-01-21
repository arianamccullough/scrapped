-- CREATE TABLE users (
--     id VARCHAR(255) NOT NULL,
--     username VARCHAR(20) NOT NULL,
--     email VARCHAR(255) NOT NULL,
--     hash VARCHAR(255) NOT NULL,
--     PRIMARY KEY (id),
--     UNIQUE KEY email (email)
-- );

-- DELETE FROM users WHERE id = 0;
-- DROP TABLE users;



-- CREATE TABLE vaults (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     location INT DEFAULT 0,
--     userId VARCHAR(255),
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );


--  INSERT INTO vaults (name, description, location) VALUES ("Cool Stuff", "It's stuff that's cool", 98765);
-- INSERT INTO vaults (name, description, location) VALUES ("Hot Stuff", "It's stuff that's hot", 98765);
-- INSERT INTO vaults (name, description, location) VALUES ("Awesome Stuff", "It's stuff that's awesome", 87654);


-- SELECT * FROM vaults

-- DELETE FROM vaults WHERE id = 0;
DROP TABLE vaults;

-- CREATE TABLE keeps (
--     id int NOT NULL AUTO_INCREMENT,
--     name VARCHAR(20) NOT NULL,
--     description VARCHAR(255) NOT NULL,
--     userId VARCHAR(255),
--     img VARCHAR(255),
--     isPrivate TINYINT,
--     location INT DEFAULT 0,
--     views INT DEFAULT 0,
--     saves INT DEFAULT 0,
--     keeps INT DEFAULT 0,
--     INDEX userId (userId),
--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,  
--     PRIMARY KEY (id)
-- );

INSERT INTO keeps (name, description, img, location, isPrivate) VALUES("Ice", "It's cold.", "https://www.foodnetwork.com/fn-dish/news/2014/10/pure-and-simple-the-cold-truth-about-clear-ice", 98765, 1)
INSERT INTO keeps (name, description, img, location, isPrivate) VALUES("The sun", "It's hot.", "https://static.bhphotovideo.com/explora/sites/default/files/styles/top_shot/public/ts-space-sun-and-solar-viewing-facts-versus-fiction.jpg?itok=gaBs6QMS", 98765, 1)
INSERT INTO keeps (name, description, img, location, isPrivate) VALUES("A unihorn", "It's awesome.", "https://www.swarovski.com/medias/?context=bWFzdGVyfHJvb3R8NTQzMjl8aW1hZ2UvanBlZ3xoZTEvaGU4LzkwMTUwODc1MzAwMTQuanBnfDFkMmZhMWI4YTQ2NmYxNDM1ZGJiYmQ3Mjk0YzJhNDQ3NzljZTUwOWE5MjJmNDY4ZmU1YTlmODViNDgzY2Q2ZGM", 87654, 0);


-- SELECT * FROM keeps

-- DELETE FROM keeps WHERE id = 0;
-- DROP TABLE keeps;


-- CREATE TABLE vaultkeeps (
--     id int NOT NULL AUTO_INCREMENT,
--     vaultId int NOT NULL,
--     keepId int NOT NULL,
--     userId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),
--     INDEX (vaultId, keepId),
--     INDEX (userId),

--     FOREIGN KEY (userId)
--         REFERENCES users(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (vaultId)
--         REFERENCES vaults(id)
--         ON DELETE CASCADE,

--     FOREIGN KEY (keepId)
--         REFERENCES keeps(id)
--         ON DELETE CASCADE
-- )


-- -- USE THIS LINE FOR GET KEEPS BY VAULTID
-- SELECT * FROM vaultkeeps vk
-- INNER JOIN keeps k ON k.id = vk.keepId 
-- WHERE (vaultId = @vaultId AND vk.userId = @userId) 
