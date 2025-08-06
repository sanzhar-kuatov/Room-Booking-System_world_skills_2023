-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 06, 2025 at 05:10 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `web_app`
--

-- --------------------------------------------------------

--
-- Table structure for table `areas`
--

CREATE TABLE `areas` (
  `ID` int(3) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `areas`
--

INSERT INTO `areas` (`ID`, `Name`) VALUES
(1, 'Seocho-gu'),
(2, '2'),
(3, 'qwerty'),
(4, 'asdf');

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `ID` int(3) NOT NULL,
  `UserID` int(3) NOT NULL,
  `AreaID` int(3) NOT NULL,
  `Title` varchar(50) NOT NULL,
  `Capacity` int(3) NOT NULL,
  `Description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`ID`, `UserID`, `AreaID`, `Title`, `Capacity`, `Description`) VALUES
(1, 1, 1, 'Первая', 2, 'Первая Первая Первая Первая Первая Первая Первая'),
(2, 2, 1, 'Вторая', 7, 'Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая Вторая '),
(3, 1, 2, 'Третья ', 2, 'Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья Третья '),
(4, 3, 1, 'Четвертая ', 3, 'Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четвертая Четве'),
(5, 2, 2, 'Пятая ', 7, 'Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая Пятая м');

-- --------------------------------------------------------

--
-- Table structure for table `pict`
--

CREATE TABLE `pict` (
  `ID` int(3) NOT NULL,
  `ItemId` int(3) NOT NULL,
  `PathPict` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pict`
--

INSERT INTO `pict` (`ID`, `ItemId`, `PathPict`) VALUES
(1, 1, 'flat1.jpg'),
(2, 2, 'flat2.jpg'),
(3, 3, 'flat3.jpg'),
(4, 4, 'flat4.png'),
(5, 5, 'flat5.jpeg');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `ID` int(3) NOT NULL,
  `Name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`ID`, `Name`) VALUES
(1, 'Alex'),
(2, 'Askar'),
(3, 'ivan'),
(4, 'Miras');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `areas`
--
ALTER TABLE `areas`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
