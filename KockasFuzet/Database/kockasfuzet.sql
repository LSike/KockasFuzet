-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2026. Feb 01. 18:24
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `kockasfuzet`
--
CREATE DATABASE IF NOT EXISTS `kockasfuzet` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `kockasfuzet`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szamla`
--

DROP TABLE IF EXISTS `szamla`;
CREATE TABLE `szamla` (
  `Id` int(11) NOT NULL,
  `SzolgaltatasAzon` int(11) NOT NULL,
  `SzolgaltatoRovid` varchar(8) NOT NULL,
  `Tol` date NOT NULL,
  `Ig` date NOT NULL,
  `Osszeg` int(11) NOT NULL,
  `Hatarido` date NOT NULL,
  `Befizetve` date DEFAULT NULL,
  `Megjegyzes` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltatas`
--

DROP TABLE IF EXISTS `szolgaltatas`;
CREATE TABLE `szolgaltatas` (
  `Id` int(11) NOT NULL,
  `Nev` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltatas`
--

INSERT INTO `szolgaltatas` (`Id`, `Nev`) VALUES
(1, 'víz'),
(2, 'villany'),
(3, 'gáz');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `szolgaltato`
--

DROP TABLE IF EXISTS `szolgaltato`;
CREATE TABLE `szolgaltato` (
  `RovidNev` varchar(8) NOT NULL,
  `Nev` varchar(256) NOT NULL,
  `Ugyfelszolgalat` varchar(256) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `szolgaltato`
--

INSERT INTO `szolgaltato` (`RovidNev`, `Nev`, `Ugyfelszolgalat`) VALUES
('ÉRV', 'ÉRV. Északmagyarországi Regionális Vízművek Zrt.', '3530 Miskolc, Corvin u. 2.'),
('MiVíz', 'MIVÍZ Kft.', '3530 Miskolc, Corvin u. 2.'),
('MVM Next', 'MVM Next Energiakereskedelmi Zrt.', '3530 Miskolc, Arany János utca 6-8.'),
('Telecom', 'Magyar Telekom Nyrt.', '3525 Miskolc, Szentpáli utca 2 - 6.');

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `szamla`
--
ALTER TABLE `szamla`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `SzolgaltatasAzon` (`SzolgaltatasAzon`),
  ADD KEY `SzolgaltatoRovid` (`SzolgaltatoRovid`);

--
-- A tábla indexei `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  ADD PRIMARY KEY (`Id`);

--
-- A tábla indexei `szolgaltato`
--
ALTER TABLE `szolgaltato`
  ADD PRIMARY KEY (`RovidNev`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `szamla`
--
ALTER TABLE `szamla`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `szolgaltatas`
--
ALTER TABLE `szolgaltatas`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `szamla`
--
ALTER TABLE `szamla`
  ADD CONSTRAINT `szamla_ibfk_1` FOREIGN KEY (`SzolgaltatasAzon`) REFERENCES `szolgaltatas` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `szamla_ibfk_2` FOREIGN KEY (`SzolgaltatoRovid`) REFERENCES `szolgaltato` (`RovidNev`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
