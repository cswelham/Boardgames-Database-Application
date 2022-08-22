--create table for manager
create table manager
(
	username varchar(12) not null,
	password varchar(12),
	primary key(username)
)

--create table for publisher
create table publisher
(
	name varchar(32)not null,
	primary key(name)
)

--create table for designer
create table designer
(
	name varchar(32) not null,
	primary key(name)
)

--create table for boardgame
create table boardgame
(
	id int not null,
	name varchar(32),
	price int,
	rating float,
	avgWeight float,
	minPlayers int,
	maxPlayers int,
	playingTime int,
	year char(4),
	avaliable varchar(3),
	primary key(id),
	check (avaliable in ('yes', 'no'))
)

--create table genre
create table genre
(
	name varchar(32) not null,
	primary key(name)
)

--create table for customer
create table customer
(
	username varchar(12) not null,
	fname varchar(32), 
	lname varchar(32),
	password varchar(12),
	phone char(10),
	email varchar(32),
	address varchar(40),
	bankAccount int,
	goodness varchar(32),
	joinDate date,
	dob date,
	gender varchar(10),
	maxRentNum int,
	primary key(username),
	check (email like '%@%.%'),
	check (goodness in ('yes', 'no')),
	check (gender in ('male', 'female', 'other'))
)

--create table rental
create table rental
(
	id int IDENTITY(100,1),
	startDate date,
	returnDate date,
	condition varchar(8),
	managerUsername varchar(12),
	customerUsername varchar(12),
	boardgameID int,
	primary key(id),
	foreign key(managerUsername) references manager,
	foreign key(customerUsername) references customer,
	foreign key(boardgameID) references boardgame,
	check (condition in ('good', 'average', 'bad'))
)

--create table publishes
create table publishes
(
	boardgameID int not null,
	publisherName varchar(32) not null,
	primary key(boardgameID, publisherName),
	foreign key(boardgameID) references boardgame,
	foreign key(publisherName) references publisher
)

--Create table designs
create table designs
(
	boardgameID int not null,
	designerName varchar(32) not null,
	primary key(boardgameID, designername),
	foreign key(boardgameID) references boardgame,
	foreign key(designerName) references designer
)

--Create table has
create table has
(
	boardgameID int not null,
	genreName varchar (32) not null,
	primary key(boardgameID, genreName),
	foreign key(boardgameID) references boardgame,
	foreign key(genreName) references genre
)

--Create table likes
create table likes
(
	customerUsername varchar(12) not null,
	genreName varchar(32) not null,
	primary key(customerUsername, genreName),
	foreign key(customerUsername) references customer,
	foreign key(genreName) references genre
)

--Create table reviews
create table reviews
(
	customerUsername varchar(12) not null,
	boardgameID int not null,
	currDate date,
	description varchar(52),
	rating float,
	primary key(customerUsername, boardgameID),
	foreign key(customerUsername) references customer,
	foreign key(boardgameID) references boardgame
)

--Insert data for 3 managers
insert into manager values('dk1', 'danielK')
insert into manager values('cv2', 'cooperV')
insert into manager values('bb3', 'benB')

--Insert data for 10 customers
insert into customer values('jk1', 'John', 'Key', 'johnK', 0211234567, 'johnkey@gmail.com', '1 Street', 123456789, 'yes', '01/01/2019', '01/01/2000', 'Male', 2)
insert into customer values('hk2', 'Helen', 'Key', 'helenK', 0212733677, 'helenkey@gmail.com', '2 Street', 123456789, 'yes', '02/01/2019', '03/05/1980', 'Female', 2)
insert into customer values('bh3', 'Bob', 'Hand', 'bobH', 0216739988, 'bobhand@gmail.com', '3 Road', 563648358, 'yes', '03/07/2019', '04/05/1963', 'Male', 2)
insert into customer values('jj4', 'Juliet', 'Jane', 'julietJ', 0213845522, 'julietjane@gmail.com', '4 Road', 823650369, 'yes', '04/07/2019', '05/05/1999', 'Female', 2)
insert into customer values('hh5', 'Harry', 'Hall', 'harryH', 0214956633, 'harryhall@gmail.com', '5 Street', 845830321, 'yes', '05/03/2019', '06/05/1972', 'Male', 2)
insert into customer values('mm6', 'Mary', 'May', 'maryM', 0213575511, 'marymay@gmail.com', '6 Crescent', 118659322, 'yes', '06/05/2019', '07/05/1975', 'Female', 2)
insert into customer values('cc7', 'Cole', 'Can', 'coleC', 0219926677, 'colecan@gmail.com', '7 Street', 268493644, 'yes', '07/02/2019', '08/05/1983', 'Male', 2)
insert into customer values('hb8', 'Helen', 'Bay', 'helenB', 0210542288, 'helenbay@gmail.com', '8 Lane', 333358370, 'yes', '08/11/2019', '09/05/1983', 'Female', 2)
insert into customer values('rr9', 'Rick', 'Roll', 'rickR', 0219034422, 'rickroll@gmail.com', '9 Street', 654356532, 'yes', '09/10/2019', '03/05/1980', 'Male', 2)
insert into customer values('mm10', 'Mia', 'Mall', 'miaM', 0210936699, 'miamall@gmail.com', '10 Lane', 346743567, 'yes', '10/12/2019', '03/05/2002', 'Female', 2)

--Insert data for 10 rentals
insert into rental values('04/05/2019', '01/05/2019', 'good', 'dk1', 'jk1', 31260)
insert into rental values('01/05/2019', '05/05/2019', 'average', 'dk1', 'hk2', 230802)
insert into rental values('02/05/2019', '06/05/2019', 'average', 'dk1', 'mm10', 102794)
insert into rental values('03/05/2019', '07/05/2019', 'good', 'dk1', 'jj4', 220308)
insert into rental values('01/05/2019', '05/05/2019', 'good', 'dk1', 'hh5', 193738)
insert into rental values('02/05/2019', '06/05/2019', 'good', 'dk1', 'mm6', 276025)
insert into rental values('03/05/2019', '08/05/2019', 'good', 'cv2', 'cc7', 204431)
insert into rental values('04/05/2019', '08/05/2019', 'average', 'cv2', 'hb8', 180956)
insert into rental values('05/05/2019', '09/05/2019', 'good', 'cv2', 'rr9', 147949)
insert into rental values('06/05/2019', '09/05/2019', 'average', 'bb3', 'bh3', 162886)

--Insert data for designer
insert into designer values('Uwe Rosenberg')
insert into designer values('Philppe Guérin')
insert into designer values('Chris Quilliams')
insert into designer values('Jens Drögemüller')
insert into designer values('Helge Ostertag')
insert into designer values('Alexander Pfister')
insert into designer values('Ted Alspach')
insert into designer values('Akihisa Okui')
insert into designer values('R. Eric Reuss')
insert into designer values('Phil Walker-Harding')
insert into designer values('Jacob Fryxelius')
insert into designer values('Elizabeth Hargrave')

--Insert data for publisher
insert into publisher values('999 Games')
insert into publisher values('Ace Studios')
insert into publisher values('ADC Blackfire Entertainment')
insert into publisher values('Adventureland Games')
insert into publisher values('Angry Lion Games')
insert into publisher values('Arclight')
insert into publisher values('Arrakis Games')
insert into publisher values('Asmodee')
insert into publisher values('AURUM, Inc.')
insert into publisher values('Bard Centrum Gier')
insert into publisher values('Bézier Games')
insert into publisher values('BoardM Factory')
insert into publisher values('Brain Games')
insert into publisher values('Broadway Toys LTD')
insert into publisher values('Capstone Games')
insert into publisher values('Cocktail Games')
insert into publisher values('Compaya.hu - Gamer Café Kft.')
insert into publisher values('Conclave Editora')
insert into publisher values('Cranio Creations')
insert into publisher values('CrowD Games')
insert into publisher values('Delta Vision Publishing')
insert into publisher values('Devir')
insert into publisher values('DiceTree Games')
insert into publisher values('Divercentro')
insert into publisher values('dlp games')
insert into publisher values('Edge Entertainment')
insert into publisher values('Ediciones MasQueOca')
insert into publisher values('eggertspiele')
insert into publisher values('Fantasmagoria')
insert into publisher values('Feuerland Spiele')
insert into publisher values('Filosofia Éditions')
insert into publisher values('Fishbone Games')
insert into publisher values('FoxMind Israel')
insert into publisher values('FryxGames')
insert into publisher values('FunBox Jogos')
insert into publisher values('Funforge')
insert into publisher values('Galápagos Jogos')
insert into publisher values('Game Harbor')
insert into publisher values('Gameland')
insert into publisher values('Games Factory')
insert into publisher values('Games Up')
insert into publisher values('Gamewright')
insert into publisher values('Gém Klub Kft.')
insert into publisher values('Gemenot')
insert into publisher values('Ghenos Games')
insert into publisher values('Gigamic')
insert into publisher values('Greater Than Games')
insert into publisher values('Hemz Universal Games Co. Ltd.')
insert into publisher values('Hobby Japan')
insert into publisher values('Hobby World')
insert into publisher values('HomoLudicus')
insert into publisher values('Intrafin Games')
insert into publisher values('KADABRA')
insert into publisher values('Kaissa Chess & Games')
insert into publisher values('Kanga Games')
insert into publisher values('Kilogames')
insert into publisher values('Korea Boardgames co., Ltd.')
insert into publisher values('Lacerta')
insert into publisher values('Lautapelit.fi')
insert into publisher values('Lavka Games')
insert into publisher values('Lex Games')
insert into publisher values('Lifestyle Boardgames Ltd')
insert into publisher values('Lookout Games')
insert into publisher values('Ludicus')
insert into publisher values('Ludofy Creative')
insert into publisher values('Maldito Games')
insert into publisher values('Mandala Jogos')
insert into publisher values('Matagot')
insert into publisher values('Mayfair Games')
insert into publisher values('Meeple BR Jogos')
insert into publisher values('MINDOK')
insert into publisher values('MYBG Co., Ltd.')
insert into publisher values('NeoTroy Games')
insert into publisher values('Next Move Games')
insert into publisher values('Orangutan Games')
insert into publisher values('Pegasus Spiele')
insert into publisher values('Plan B Games')
insert into publisher values('Playfun Games')
insert into publisher values('Ravensburger Spieleverlag GmbH')
insert into publisher values('Rebel')
insert into publisher values('Reflexshop')
insert into publisher values('Regatul Jocurilor')
insert into publisher values('Schwerkraft-Verlag')
insert into publisher values('Siam Board Games')
insert into publisher values('Smart Ltd')
insert into publisher values('Stonemaier Games')
insert into publisher values('Stratelibri')
insert into publisher values('Stronghold Games')
insert into publisher values('Super Meeple')
insert into publisher values('Surfin Meeple')
insert into publisher values('Surfin Meeple China')
insert into publisher values('Swan Panasia Co., Ltd.')
insert into publisher values('Tower Tactic Games')
insert into publisher values('TWOPLUS Games')
insert into publisher values('uplay.it edizioni')
insert into publisher values('Viravi Edicions')
insert into publisher values('White Goblin Games')
insert into publisher values('YOKA Games')
insert into publisher values('Ystari Games')
insert into publisher values('Z-Man Games, Inc.')
insert into publisher values('Zoch Verlag')
insert into publisher values('Zvezda')
insert into publisher values('Ten Days Games')

--Insert data for genres
insert into genre values('Abstract Strategy')
insert into genre values('Age of Reason')
insert into genre values('American West')
insert into genre values('Animals')
insert into genre values('Bluffing')
insert into genre values('Card Drafting')
insert into genre values('Card Game')
insert into genre values('Civilization')
insert into genre values('Deduction')
insert into genre values('Drafting')
insert into genre values('Economic')
insert into genre values('Educational')
insert into genre values('Environmental')
insert into genre values('Exploration')
insert into genre values('Fantasy')
insert into genre values('Farming')
insert into genre values('Fighting')
insert into genre values('Hand Management')
insert into genre values('Horror')
insert into genre values('Industry / Manufacturing')
insert into genre values('Mythology')
insert into genre values('Party Game')
insert into genre values('Renaissance')
insert into genre values('Science Fiction')
insert into genre values('Set Collection')
insert into genre values('Simultaneous Action Selection')
insert into genre values('Space Exploration')
insert into genre values('Territory Building')

--Insert data for boardgames
insert into boardgame values(31260, 'Agricola', null, 7.96682, 3.639, 1, 5, 150, 2007, 'yes')
insert into boardgame values(230802, 'Azul', null, 7.85835, 1.7785, 2, 4, 45, 2017, 'yes')
insert into boardgame values(102794, 'Caverna: The Cave Farmers', null, 8.0392, 3.7843, 1, 7, 210, 2013, 'yes')
insert into boardgame values(220308, 'Gaia Project', null, 8.49592, 4.3189, 1, 4, 150, 2017, 'yes')
insert into boardgame values(193738, 'Great Western Trail', null, 8.28423, 3.6956, 2, 4, 150, 2016, 'yes')
insert into boardgame values(276025, 'Maracaibo', null, 8.27257, 3.9005, 1, 5, 150, 2019, 'yes')
insert into boardgame values(204431, 'One Night Ultimate Alien', null, 7.07577, 1.8636, 4, 10, 10, 2017, 'yes')
insert into boardgame values(180956, 'One Night Ultimate Vampire', null, 6.74924, 1.5405, 3, 10, 10, 2015, 'yes')
insert into boardgame values(147949, 'One Night Ultimate Werewolf', null, 7.16687, 1.3978, 3, 10, 10, 2014, 'yes')
insert into boardgame values(162886, 'Spirit Island', null, 8.31674, 3.9581, 1, 4, 120, 2017, 'yes')
insert into boardgame values(192291, 'Sushi Go Party!', null, 7.48268, 1.324, 2, 8, 20, 2016, 'yes')
insert into boardgame values(133473, 'Sushi Go!', null, 7.05894, 1.1621, 2, 5, 15, 2013, 'yes')
insert into boardgame values(120677, 'Terra Mystica', null, 8.16544, 3.9521, 2, 5, 150, 2012, 'yes')
insert into boardgame values(167791, 'Terraforming Mars', null, 8.42498, 3.2362, 1, 5, 120, 2016, 'yes')
insert into boardgame values(266192, 'Wingspan', null, 8.1218, 2.3676, 1, 5, 70, 2019, 'yes')

--Link boardgames with publishers
insert into publishes values(31260, 'Lookout Games')
insert into publishes values(31260, '999 Games')
insert into publishes values(31260, 'Brain Games')
insert into publishes values(31260, 'Compaya.hu - Gamer Café Kft.')
insert into publishes values(31260, 'Devir')
insert into publishes values(31260, 'Filosofia Éditions')
insert into publishes values(31260, 'Funforge')
insert into publishes values(31260, 'Hobby Japan')
insert into publishes values(31260, 'Hobby World')
insert into publishes values(31260, 'HomoLudicus')
insert into publishes values(31260, 'Korea Boardgames co., Ltd.')
insert into publishes values(31260, 'Lacerta')
insert into publishes values(31260, 'MINDOK')
insert into publishes values(31260, 'Smart Ltd')
insert into publishes values(31260, 'Stratelibri')
insert into publishes values(31260, 'Swan Panasia Co., Ltd.')
insert into publishes values(31260, 'Ystari Games')
insert into publishes values(31260, 'Z-Man Games, Inc.')

insert into publishes values(230802, 'Next Move Games')
insert into publishes values(230802, 'Plan B Games')
insert into publishes values(230802, 'Asmodee')
insert into publishes values(230802, 'Broadway Toys LTD')
insert into publishes values(230802, 'Divercentro')
insert into publishes values(230802, 'Galápagos Jogos')
insert into publishes values(230802, 'Gém Klub Kft.')
insert into publishes values(230802, 'Ghenos Games')
insert into publishes values(230802, 'Hobby Japan')
insert into publishes values(230802, 'KADABRA')
insert into publishes values(230802, 'Kaissa Chess & Games')
insert into publishes values(230802, 'Korea Boardgames co., Ltd.')
insert into publishes values(230802, 'Lacerta')
insert into publishes values(230802, 'MINDOK')
insert into publishes values(230802, 'Orangutan Games')
insert into publishes values(230802, 'Pegasus Spiele')
insert into publishes values(230802, 'Tower Tactic Games')
insert into publishes values(230802, 'TWOPLUS Games')
insert into publishes values(230802, 'Zvezda')

insert into publishes values(102794, 'Lookout Games')
insert into publishes values(102794, '999 Games')
insert into publishes values(102794, 'CrowD Games')
insert into publishes values(102794, 'Devir')
insert into publishes values(102794, 'Filosofia Éditions')
insert into publishes values(102794, 'Funforge')
insert into publishes values(102794, 'Gemenot')
insert into publishes values(102794, 'Hobby Japan')
insert into publishes values(102794, 'HomoLudicus')
insert into publishes values(102794, 'Korea Boardgames co., Ltd.')
insert into publishes values(102794, 'Lacerta')
insert into publishes values(102794, 'Ludofy Creative')
insert into publishes values(102794, 'Mayfair Games')
insert into publishes values(102794, 'MINDOK')
insert into publishes values(102794, 'Swan Panasia Co., Ltd.')
insert into publishes values(102794, 'uplay.it edizioni')

insert into publishes values(220308, 'Feuerland Spiele')
insert into publishes values(220308, 'Cranio Creations')
insert into publishes values(220308, 'DiceTree Games')
insert into publishes values(220308, 'Edge Entertainment')
insert into publishes values(220308, 'Game Harbor')
insert into publishes values(220308, 'Games Factory')
insert into publishes values(220308, 'Hobby World')
insert into publishes values(220308, 'Maldito Games')
insert into publishes values(220308, 'Mandala Jogos')
insert into publishes values(220308, 'Reflexshop')
insert into publishes values(220308, 'Ten Days Games')
insert into publishes values(220308, 'White Goblin Games')
insert into publishes values(220308, 'Z-Man Games, Inc.')

insert into publishes values(193738, 'eggertspiele')
insert into publishes values(193738, '999 Games')
insert into publishes values(193738, 'Arclight')
insert into publishes values(193738, 'Broadway Toys LTD')
insert into publishes values(193738, 'Conclave Editora')
insert into publishes values(193738, 'Delta Vision Publishing')
insert into publishes values(193738, 'Ediciones MasQueOca')
insert into publishes values(193738, 'Gigamic')
insert into publishes values(193738, 'Korea Boardgames co., Ltd.')
insert into publishes values(193738, 'Lacerta')
insert into publishes values(193738, 'Ludicus')
insert into publishes values(193738, 'MINDOK')
insert into publishes values(193738, 'Pegasus Spiele')
insert into publishes values(193738, 'Plan B Games')
insert into publishes values(193738, 'Stronghold Games')
insert into publishes values(193738, 'uplay.it edizioni')
insert into publishes values(193738, 'Zvezda')

insert into publishes values(276025, 'Games Up')
insert into publishes values(276025, 'BoardM Factory')
insert into publishes values(276025, 'Capstone Games')
insert into publishes values(276025, 'dlp games')
insert into publishes values(276025, 'Ediciones MasQueOca')
insert into publishes values(276025, 'Fishbone Games')
insert into publishes values(276025, 'Super Meeple')
insert into publishes values(276025, 'YOKA Games')

insert into publishes values(204431, 'Bézier Games')

insert into publishes values(180956, 'Bézier Games')
insert into publishes values(180956, 'Ravensburger Spieleverlag GmbH')
insert into publishes values(180956, 'White Goblin Games')

insert into publishes values(147949, 'Bézier Games')
insert into publishes values(147949, 'Lacerta')
insert into publishes values(147949, 'Playfun Games')
insert into publishes values(147949, 'Ravensburger Spieleverlag GmbH')
insert into publishes values(147949, 'Reflexshop')
insert into publishes values(147949, 'Siam Board Games')
insert into publishes values(147949, 'Viravi Edicions')
insert into publishes values(147949, 'White Goblin Games')

insert into publishes values(162886, 'Greater Than Games')
insert into publishes values(162886, 'Ace Studios')
insert into publishes values(162886, 'Arrakis Games')
insert into publishes values(162886, 'BoardM Factory')
insert into publishes values(162886, 'Gém Klub Kft.')
insert into publishes values(162886, 'Ghenos Games')
insert into publishes values(162886, 'Hobby World')
insert into publishes values(162886, 'Intrafin Games')
insert into publishes values(162886, 'Lacerta')
insert into publishes values(162886, 'Pegasus Spiele')

insert into publishes values(192291, 'Gamewright')
insert into publishes values(192291, 'Devir')
insert into publishes values(192291, 'Rebel')
insert into publishes values(192291, 'Reflexshop')
insert into publishes values(192291, 'uplay.it edizioni')
insert into publishes values(192291, 'White Goblin Games')
insert into publishes values(192291, 'Zoch Verlag')

insert into publishes values(133473, 'Adventureland Games')
insert into publishes values(133473, 'ADC Blackfire Entertainment')
insert into publishes values(133473, 'AURUM, Inc.')
insert into publishes values(133473, 'Cocktail Games')
insert into publishes values(133473, 'Devir')
insert into publishes values(133473, 'FoxMind Israel')
insert into publishes values(133473, 'Gameland')
insert into publishes values(133473, 'Gamewright')
insert into publishes values(133473, 'Hemz Universal Games Co. Ltd.')
insert into publishes values(133473, 'Kanga Games')
insert into publishes values(133473, 'Lifestyle Boardgames Ltd')
insert into publishes values(133473, 'NeoTroy Games')
insert into publishes values(133473, 'Rebel')
insert into publishes values(133473, 'Reflexshop')
insert into publishes values(133473, 'uplay.it edizioni')
insert into publishes values(133473, 'White Goblin Games')
insert into publishes values(133473, 'Zoch Verlag')

insert into publishes values(120677, 'Feuerland Spiele')
insert into publishes values(120677, 'Bard Centrum Gier')
insert into publishes values(120677, 'Cranio Creations')
insert into publishes values(120677, 'Devir')
insert into publishes values(120677, 'Filosofia Éditions')
insert into publishes values(120677, 'FunBox Jogos')
insert into publishes values(120677, 'Gém Klub Kft.')
insert into publishes values(120677, 'HomoLudicus')
insert into publishes values(120677, 'Mandala Jogos')
insert into publishes values(120677, 'MINDOK')
insert into publishes values(120677, 'Swan Panasia Co., Ltd.')
insert into publishes values(120677, 'Ten Days Games')
insert into publishes values(120677, 'White Goblin Games')
insert into publishes values(120677, 'Z-Man Games, Inc.')
insert into publishes values(120677, 'Zvezda')

insert into publishes values(167791, 'FryxGames')
insert into publishes values(167791, 'Arclight')
insert into publishes values(167791, 'Fantasmagoria')
insert into publishes values(167791, 'Ghenos Games')
insert into publishes values(167791, 'Intrafin Games')
insert into publishes values(167791, 'Kilogames')
insert into publishes values(167791, 'Korea Boardgames co., Ltd.')
insert into publishes values(167791, 'Lautapelit.fi')
insert into publishes values(167791, 'Lavka Games')
insert into publishes values(167791, 'Lex Games')
insert into publishes values(167791, 'Maldito Games')
insert into publishes values(167791, 'Meeple BR Jogos')
insert into publishes values(167791, 'MINDOK')
insert into publishes values(167791, 'MYBG Co., Ltd.')
insert into publishes values(167791, 'NeoTroy Games')
insert into publishes values(167791, 'Rebel')
insert into publishes values(167791, 'Reflexshop')
insert into publishes values(167791, 'Schwerkraft-Verlag')
insert into publishes values(167791, 'Siam Board Games')
insert into publishes values(167791, 'Stronghold Games')

insert into publishes values(266192, 'Stonemaier Games')
insert into publishes values(266192, '999 Games')
insert into publishes values(266192, 'Angry Lion Games')
insert into publishes values(266192, 'Delta Vision Publishing')
insert into publishes values(266192, 'Divercentro')
insert into publishes values(266192, 'Feuerland Spiele')
insert into publishes values(266192, 'Ghenos Games')
insert into publishes values(266192, 'Lautapelit.fi')
insert into publishes values(266192, 'Lavka Games')
insert into publishes values(266192, 'Ludofy Creative')
insert into publishes values(266192, 'Maldito Games')
insert into publishes values(266192, 'Matagot')
insert into publishes values(266192, 'MINDOK')
insert into publishes values(266192, 'Rebel')
insert into publishes values(266192, 'Regatul Jocurilor')
insert into publishes values(266192, 'Siam Board Games')
insert into publishes values(266192, 'Surfin Meeple')
insert into publishes values(266192, 'Surfin Meeple China')

--Link boardgames with developers
insert into designs values(31260, 'Uwe Rosenberg')

insert into designs values(230802, 'Philippe Guérin')
insert into designs values(230802, 'Chris Quilliams')

insert into designs values(102794, 'Uwe Rosenberg')

insert into designs values(220308, 'Jens Drögemüller')
insert into designs values(220308, 'Helge Ostertag')

insert into designs values(193738, 'Alexander Pfister')

insert into designs values(276025, 'Alexander Pfister')

insert into designs values(204431, 'Ted Alspach')
insert into designs values(204431, 'Akihisa Okui')

insert into designs values(180956, 'Ted Alspach')
insert into designs values(180956, 'Akihisa Okui')

insert into designs values(147949, 'Ted Alspach')
insert into designs values(147949, 'Akihisa Okui')

insert into designs values(162886, 'R. Eric Reuss')

insert into designs values(192291, 'Phil Walker-Harding')

insert into designs values(133473, 'Phil Walker-Harding')

insert into designs values(120677, 'Jens Drögemüller')
insert into designs values(120677, 'Helge Ostertag')

insert into designs values(167791, 'Jacob Fryxelius')

insert into designs values(266192, 'Elizabeth Hargrave')

--Link boardgames with genres
insert into has values(31260, 'Animals')
insert into has values(31260, 'Economic')
insert into has values(31260, 'Farming')

insert into has values(230802, 'Abstract Strategy')
insert into has values(230802, 'Renaissance')

insert into has values(102794, 'Animals')
insert into has values(102794, 'Economic')
insert into has values(102794, 'Fantasy')
insert into has values(102794, 'Farming')

insert into has values(220308, 'Civilization')
insert into has values(220308, 'Economic')
insert into has values(220308, 'Science Fiction')
insert into has values(220308, 'Space Exploration')
insert into has values(220308, 'Territory Building')

insert into has values(193738, 'American West')
insert into has values(193738, 'Animals')

insert into has values(276025, 'Economic')
insert into has values(276025, 'Exploration')

insert into has values(204431, 'Bluffing')
insert into has values(204431, 'Card game')
insert into has values(204431, 'Deduction')
insert into has values(204431, 'Horror')
insert into has values(204431, 'Party Game')

insert into has values(180956, 'Bluffing')
insert into has values(180956, 'Card Game')
insert into has values(180956, 'Deduction')
insert into has values(180956, 'Horror')
insert into has values(180956, 'Party Game')

insert into has values(147949, 'Bluffing')
insert into has values(147949, 'Card Game')
insert into has values(147949, 'Deduction')
insert into has values(147949, 'Horror')
insert into has values(147949, 'Party Game')

insert into has values(162886, 'Age of Reason')
insert into has values(162886, 'Environmental')
insert into has values(162886, 'Fantasy')
insert into has values(162886, 'Fighting')
insert into has values(162886, 'Mythology')
insert into has values(162886, 'Territory Building')

insert into has values(192291, 'Card Drafting')
insert into has values(192291, 'Hand Management')
insert into has values(192291, 'Set Collection')
insert into has values(192291, 'Simultaneous Action Selection')

insert into has values(133473, 'Card Drafting')
insert into has values(133473, 'Drafting')
insert into has values(133473, 'Hand Management')
insert into has values(133473, 'Set Collection')
insert into has values(133473, 'Simultaneous Action Selection')

insert into has values(120677, 'Civilization')
insert into has values(120677, 'Economic')
insert into has values(120677, 'Fantasy')
insert into has values(120677, 'Territory Building')

insert into has values(167791, 'Economic')
insert into has values(167791, 'Environmental')
insert into has values(167791, 'Industry / Manufacturing')
insert into has values(167791, 'Science Fiction')
insert into has values(167791, 'Space Exploration')
insert into has values(167791, 'Territory Building')

insert into has values(266192, 'Animals')
insert into has values(266192, 'Card Game')
insert into has values(266192, 'Economic')
insert into has values(266192, 'Educational')

--Insert into likes
insert into likes values('jk1', 'Abstract Strategy')
insert into likes values('jk1', 'Economic')
insert into likes values('jk1', 'Educational')

insert into likes values('hk2', 'Card Game')
insert into likes values('hk2', 'Environmental')
insert into likes values('hk2', 'Drafting')

--Show tables
select * from boardgame order by id asc
select * from designer order by name asc
select * from publisher order by name asc
select * from genre order by name asc
select * from publishes order by boardgameID asc
select * from designs order by boardgameID asc
select * from has order by boardgameID asc

select * from manager order by username asc
select * from customer order by username asc
select * from reviews
select * from rental
select * from likes

select r.*, b.name
from reviews r, boardgame b
where r.boardgameID = b.id
order by b.name

select id from boardgame where name = 'Agricola'

update boardgame
set avaliable = 'no'
where id in (
select boardgameID from rental
where customerUsername = 'rr9')