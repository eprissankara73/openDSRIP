-- phpMyAdmin SQL Dump
-- version 4.6.6deb5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3306
-- Generation Time: May 27, 2020 at 10:51 PM
-- Server version: 5.7.30-0ubuntu0.18.04.1
-- PHP Version: 7.2.24-0ubuntu0.18.04.4

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dsrip-ppd`
--
CREATE DATABASE IF NOT EXISTS `dsrip-ppd` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `dsrip-ppd`;

-- --------------------------------------------------------

--
-- Table structure for table `batteries`
--

CREATE TABLE `batteries` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `batteryid` varchar(36) NOT NULL,
  `name` varchar(512) NOT NULL,
  `endUse` varchar(16) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `battery_channel_device_map`
--

CREATE TABLE `battery_channel_device_map` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `batteryid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `channel_name` varchar(64) NOT NULL,
  `type` varchar(16) NOT NULL DEFAULT 'Other',
  `recorded_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `battery_data_template`
--

CREATE TABLE `battery_data_template` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `batteryid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `value` varchar(16) NOT NULL,
  `time_stamp` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `load_channel_device_map`
--

CREATE TABLE `load_channel_device_map` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `loadid` varchar(36) NOT NULL,
  `name` varchar(64) NOT NULL,
  `type` varchar(16) NOT NULL DEFAULT 'Other',
  `recorded_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `load_data_template`
--

CREATE TABLE `load_data_template` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `loadid` varchar(36) NOT NULL,
  `value` decimal(20,10) NOT NULL,
  `units` varchar(12) NOT NULL DEFAULT 'kW',
  `time_stamp` int(16) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `sites`
--

CREATE TABLE `sites` (
  `tableid` int(11) NOT NULL,
  `utilityid` varchar(36) NOT NULL DEFAULT '1',
  `siteid` varchar(36) NOT NULL,
  `name` varchar(512) NOT NULL,
  `city` varchar(32) NOT NULL,
  `state` varchar(16) NOT NULL,
  `zipcode` varchar(12) NOT NULL,
  `timezone` varchar(32) NOT NULL,
  `hassolar` int(2) NOT NULL,
  `sqfootage` int(10) NOT NULL,
  `type` varchar(16) NOT NULL,
  `floors` int(3) NOT NULL,
  `year` int(4) NOT NULL,
  `occupants` int(4) NOT NULL,
  `marketContext` varchar(24) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tstats`
--

CREATE TABLE `tstats` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `tstatid` varchar(36) NOT NULL,
  `name` varchar(512) NOT NULL,
  `endUse` varchar(16) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tstat_channel_device_map`
--

CREATE TABLE `tstat_channel_device_map` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `tstatid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `channel_name` varchar(64) NOT NULL,
  `type` varchar(16) NOT NULL DEFAULT 'Other',
  `recorded_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tstat_data_template`
--

CREATE TABLE `tstat_data_template` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `tstatid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `value` varchar(16) NOT NULL,
  `time_stamp` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `utilities`
--

CREATE TABLE `utilities` (
  `tableid` int(11) NOT NULL,
  `utilityid` varchar(36) NOT NULL,
  `utility_name` varchar(512) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `waterheaters`
--

CREATE TABLE `waterheaters` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `waterheaterid` varchar(36) NOT NULL,
  `name` varchar(512) NOT NULL,
  `endUse` varchar(16) NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `waterheater_channel_device_map`
--

CREATE TABLE `waterheater_channel_device_map` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `waterheaterid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `channel_name` varchar(64) NOT NULL,
  `type` varchar(16) NOT NULL DEFAULT 'Other',
  `recorded_time` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `waterheater_data_template`
--

CREATE TABLE `waterheater_data_template` (
  `tableid` int(11) NOT NULL,
  `siteid` varchar(36) NOT NULL DEFAULT '1',
  `waterheaterid` varchar(36) NOT NULL,
  `cid` varchar(32) NOT NULL,
  `value` varchar(16) NOT NULL,
  `time_stamp` datetime NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `batteries`
--
ALTER TABLE `batteries`
  ADD PRIMARY KEY (`tableid`);

--
-- Indexes for table `battery_channel_device_map`
--
ALTER TABLE `battery_channel_device_map`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`);

--
-- Indexes for table `battery_data_template`
--
ALTER TABLE `battery_data_template`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`),
  ADD KEY `time_stamp` (`time_stamp`);

--
-- Indexes for table `load_channel_device_map`
--
ALTER TABLE `load_channel_device_map`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`loadid`),
  ADD KEY `siteid` (`siteid`);

--
-- Indexes for table `load_data_template`
--
ALTER TABLE `load_data_template`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`loadid`),
  ADD KEY `time_stamp` (`time_stamp`),
  ADD KEY `siteid` (`siteid`);

--
-- Indexes for table `sites`
--
ALTER TABLE `sites`
  ADD PRIMARY KEY (`tableid`);

--
-- Indexes for table `tstats`
--
ALTER TABLE `tstats`
  ADD PRIMARY KEY (`tableid`);

--
-- Indexes for table `tstat_channel_device_map`
--
ALTER TABLE `tstat_channel_device_map`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`);

--
-- Indexes for table `tstat_data_template`
--
ALTER TABLE `tstat_data_template`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`),
  ADD KEY `time_stamp` (`time_stamp`);

--
-- Indexes for table `utilities`
--
ALTER TABLE `utilities`
  ADD PRIMARY KEY (`tableid`);

--
-- Indexes for table `waterheaters`
--
ALTER TABLE `waterheaters`
  ADD PRIMARY KEY (`tableid`);

--
-- Indexes for table `waterheater_channel_device_map`
--
ALTER TABLE `waterheater_channel_device_map`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`);

--
-- Indexes for table `waterheater_data_template`
--
ALTER TABLE `waterheater_data_template`
  ADD PRIMARY KEY (`tableid`),
  ADD KEY `cid` (`cid`),
  ADD KEY `time_stamp` (`time_stamp`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `batteries`
--
ALTER TABLE `batteries`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `battery_channel_device_map`
--
ALTER TABLE `battery_channel_device_map`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `battery_data_template`
--
ALTER TABLE `battery_data_template`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `load_channel_device_map`
--
ALTER TABLE `load_channel_device_map`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=157;
--
-- AUTO_INCREMENT for table `load_data_template`
--
ALTER TABLE `load_data_template`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `sites`
--
ALTER TABLE `sites`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `tstats`
--
ALTER TABLE `tstats`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `tstat_channel_device_map`
--
ALTER TABLE `tstat_channel_device_map`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=133;
--
-- AUTO_INCREMENT for table `tstat_data_template`
--
ALTER TABLE `tstat_data_template`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `utilities`
--
ALTER TABLE `utilities`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `waterheaters`
--
ALTER TABLE `waterheaters`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `waterheater_channel_device_map`
--
ALTER TABLE `waterheater_channel_device_map`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `waterheater_data_template`
--
ALTER TABLE `waterheater_data_template`
  MODIFY `tableid` int(11) NOT NULL AUTO_INCREMENT;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
