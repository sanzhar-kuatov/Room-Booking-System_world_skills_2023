-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 17, 2024 at 11:08 AM
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
-- Database: `project`
--

-- --------------------------------------------------------

--
-- Table structure for table `areas`
--

CREATE TABLE `areas` (
  `id` int(11) NOT NULL,
  `name` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `areas`
--

INSERT INTO `areas` (`id`, `name`) VALUES
(1, 'Алматинская область'),
(2, 'Актюбинская область'),
(3, 'Акмолинская область'),
(4, 'Неизвестно');

-- --------------------------------------------------------

--
-- Table structure for table `itemprices`
--

CREATE TABLE `itemprices` (
  `id` int(11) NOT NULL,
  `itemid` int(11) NOT NULL,
  `start_date` varchar(300) NOT NULL,
  `end_date` varchar(300) NOT NULL,
  `price` int(11) NOT NULL,
  `rule` int(11) NOT NULL,
  `photo_path` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `itemprices`
--

INSERT INTO `itemprices` (`id`, `itemid`, `start_date`, `end_date`, `price`, `rule`, `photo_path`) VALUES
(1, 1, '2024/04/19', '2024/04/22', 150, 2, 'flat1.jpg'),
(2, 2, '2024/04/27', '2024/05/12', 200, 3, 'flat2.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `items`
--

CREATE TABLE `items` (
  `id` int(11) NOT NULL,
  `areaid` int(11) NOT NULL,
  `capacity` int(11) NOT NULL,
  `description` varchar(300) NOT NULL,
  `title` varchar(300) NOT NULL,
  `userid` int(11) NOT NULL,
  `typeid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `items`
--

INSERT INTO `items` (`id`, `areaid`, `capacity`, `description`, `title`, `userid`, `typeid`) VALUES
(1, 3, 2, 'Фантастическое место для отдыха!', 'Millenium Hotel', 2, 1),
(2, 1, 1, 'В тесноте да не в обиде!', 'Ploskiy Hostel', 4, 1),
(3, 2, 6, 'Всегда рядом, даже когда далеко!', 'Faraway Hotel', 1, 1),
(4, 4, 0, 'С улыбкой и любовью встречает вас мы!', 'Love Hotel/us', 3, 1),
(5, 3, 15, 'Богато жить не запретишь!', 'Million hotel', 4, 1);

-- --------------------------------------------------------

--
-- Table structure for table `pict`
--

CREATE TABLE `pict` (
  `id` int(11) NOT NULL,
  `itemid` int(11) NOT NULL,
  `pathpict` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `pict`
--

INSERT INTO `pict` (`id`, `itemid`, `pathpict`) VALUES
(1, 1, 'flat1.jpg'),
(2, 2, 'flat2.jpg'),
(3, 3, 'flat3.jpg'),
(4, 4, 'flat4.png'),
(5, 5, 'flat5.jpeg');

-- --------------------------------------------------------

--
-- Table structure for table `rules`
--

CREATE TABLE `rules` (
  `id` int(11) NOT NULL,
  `name` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rules`
--

INSERT INTO `rules` (`id`, `name`) VALUES
(1, 'Легкие правила'),
(2, 'Средние правила'),
(3, 'Сложные правила'),
(4, 'Нету информации');

-- --------------------------------------------------------

--
-- Table structure for table `types`
--

CREATE TABLE `types` (
  `id` int(11) NOT NULL,
  `name` varchar(300) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `types`
--

INSERT INTO `types` (`id`, `name`) VALUES
(1, 'Публичная комната'),
(2, 'Приватная комната'),
(3, 'Премиум помещение'),
(4, 'Нету информации');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `id` int(11) NOT NULL,
  `name` varchar(30) NOT NULL,
  `password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `password`) VALUES
(1, '123', '123'),
(2, 'Санжар', 'nopasswordallowed'),
(3, 'Marzhan', 'mozhetzhekogdahochet'),
(4, 'Akzhol', 'SalamBrotishka');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `areas`
--
ALTER TABLE `areas`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `itemprices`
--
ALTER TABLE `itemprices`
  ADD PRIMARY KEY (`id`),
  ADD KEY `itemid` (`itemid`),
  ADD KEY `rule` (`rule`);

--
-- Indexes for table `items`
--
ALTER TABLE `items`
  ADD PRIMARY KEY (`id`),
  ADD KEY `areaid` (`areaid`,`userid`),
  ADD KEY `userid` (`userid`),
  ADD KEY `typeid` (`typeid`);

--
-- Indexes for table `pict`
--
ALTER TABLE `pict`
  ADD PRIMARY KEY (`id`),
  ADD KEY `itemid` (`itemid`);

--
-- Indexes for table `rules`
--
ALTER TABLE `rules`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `types`
--
ALTER TABLE `types`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `itemprices`
--
ALTER TABLE `itemprices`
  ADD CONSTRAINT `itemprices_ibfk_1` FOREIGN KEY (`itemid`) REFERENCES `items` (`id`),
  ADD CONSTRAINT `itemprices_ibfk_2` FOREIGN KEY (`rule`) REFERENCES `rules` (`id`);

--
-- Constraints for table `items`
--
ALTER TABLE `items`
  ADD CONSTRAINT `items_ibfk_1` FOREIGN KEY (`userid`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `items_ibfk_2` FOREIGN KEY (`areaid`) REFERENCES `areas` (`id`),
  ADD CONSTRAINT `items_ibfk_3` FOREIGN KEY (`typeid`) REFERENCES `types` (`id`);

--
-- Constraints for table `pict`
--
ALTER TABLE `pict`
  ADD CONSTRAINT `pict_ibfk_1` FOREIGN KEY (`itemid`) REFERENCES `items` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
