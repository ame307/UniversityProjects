CREATE TABLE `scoreboard` (
  `Username` varchar(20) NOT NULL,
  `Password` varchar(20) NOT NULL,
  `Score` int(11) DEFAULT '0',
  PRIMARY KEY (`Username`),
  UNIQUE KEY `Username_UNIQUE` (`Username`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

INSERT INTO scoreboard VALUES('P1','egy',1000);
INSERT INTO scoreboard VALUES('P2','kettő',900);
INSERT INTO scoreboard VALUES('P3','három',800);
INSERT INTO scoreboard VALUES('P4','négy',700);
INSERT INTO scoreboard VALUES('P5','öt',600);
INSERT INTO scoreboard VALUES('P6','hat',500);
INSERT INTO scoreboard VALUES('P7','hét',400);
INSERT INTO scoreboard VALUES('P8','nyolc',300);
INSERT INTO scoreboard VALUES('P9','kilenc',200);
INSERT INTO scoreboard VALUES('P10','tíz',100);
