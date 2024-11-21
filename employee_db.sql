-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 21 Nov 2024 pada 08.28
-- Versi server: 10.4.17-MariaDB
-- Versi PHP: 8.2.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `employee_db`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `employeehistory`
--

CREATE TABLE `employeehistory` (
  `Id` int(11) NOT NULL,
  `EmployeeId` int(11) DEFAULT NULL,
  `EmploymentStatusId` int(11) DEFAULT NULL,
  `WorkUnitId` int(11) DEFAULT NULL,
  `PositionId` int(11) DEFAULT NULL,
  `ChangeDate` datetime NOT NULL,
  `ChangeType` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `employeehistory`
--

INSERT INTO `employeehistory` (`Id`, `EmployeeId`, `EmploymentStatusId`, `WorkUnitId`, `PositionId`, `ChangeDate`, `ChangeType`) VALUES
(1, 1, 2, 1, 5, '2022-09-18 00:00:00', 'Initial Entry'),
(2, 1, 1, 1, 3, '2024-09-27 20:32:12', 'Update'),
(3, 2, 2, 2, 2, '2023-01-05 00:00:00', 'Initial Entry'),
(4, 2, 1, 2, 2, '2024-09-27 20:32:12', 'Update'),
(5, 6, 1, 5, 5, '2024-09-27 21:46:21', 'Initial Entry'),
(6, 7, 2, 5, 5, '2024-09-27 22:06:41', 'Initial Entry'),
(7, 8, 2, 5, 5, '2024-09-27 22:48:26', 'Initial Entry'),
(8, 9, 1, 6, 1, '2024-09-28 09:21:16', 'Initial Entry'),
(12, 13, 1, 6, 1, '2024-09-28 11:25:46', 'Initial Entry'),
(13, 8, 2, 6, 5, '2024-09-28 11:36:24', 'Update'),
(14, 8, 2, 6, 4, '2024-09-28 11:40:45', 'Update'),
(15, 8, 2, 6, 5, '2024-09-28 11:48:52', 'Update'),
(16, 8, 2, 5, 5, '2024-09-28 11:48:59', 'Update'),
(17, 8, 2, 6, 4, '2024-09-28 11:55:29', 'Update'),
(18, 8, 2, 6, 5, '2024-09-28 12:13:40', 'Update'),
(19, 8, 2, 6, 4, '2024-09-28 12:20:43', 'Update'),
(20, 15, 1, 6, 1, '2024-09-28 12:21:27', 'Initial Entry'),
(22, 8, 2, 6, 4, '2024-09-28 12:56:53', 'Update'),
(23, 8, 2, 6, 3, '2024-09-28 13:48:46', 'Update'),
(27, 8, 1, 6, 5, '2024-09-28 15:12:01', 'Update'),
(28, 18, 1, 6, 1, '2024-09-28 15:14:30', 'Initial Entry'),
(32, 20, 1, 6, 1, '2024-10-01 12:55:28', 'Initial Entry'),
(33, 21, 1, 6, 4, '2024-10-01 13:04:27', 'Initial Entry'),
(34, 22, 1, 6, 1, '2024-10-01 13:04:43', 'Initial Entry'),
(35, 23, 1, 6, 1, '2024-10-01 13:08:19', 'Initial Entry'),
(36, 24, 1, 6, 1, '2024-10-01 15:00:47', 'Initial Entry'),
(37, 25, 1, 1, 1, '2024-10-01 15:06:59', 'Initial Entry'),
(38, 26, 1, 2, 3, '2024-10-01 17:42:01', 'Initial Entry'),
(39, 27, 1, 6, 1, '2024-10-01 19:44:24', 'Initial Entry'),
(44, 30, 1, 6, 1, '2024-10-03 09:32:02', 'Initial Entry');

-- --------------------------------------------------------

--
-- Struktur dari tabel `employees`
--

CREATE TABLE `employees` (
  `Id` int(11) NOT NULL,
  `EmployeeNumber` varchar(50) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Gender` varchar(10) NOT NULL,
  `PlaceOfBirth` varchar(100) NOT NULL,
  `DateOfBirth` date NOT NULL,
  `EmploymentStatusId` int(11) DEFAULT NULL,
  `WorkUnitId` int(11) DEFAULT NULL,
  `PositionId` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `employees`
--

INSERT INTO `employees` (`Id`, `EmployeeNumber`, `Name`, `Gender`, `PlaceOfBirth`, `DateOfBirth`, `EmploymentStatusId`, `WorkUnitId`, `PositionId`) VALUES
(1, 'E001', 'Ali Rahman', 'Laki-laki', 'Jakarta', '1990-01-15', 1, 1, 1),
(2, 'E002', 'Siti Aminah', 'Perempuan', 'Bandung', '1992-03-22', 2, 2, 2),
(3, 'E003', 'Budi Santoso', 'Laki-laki', 'Surabaya', '1988-05-10', 1, 3, 4),
(4, 'E004', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(5, 'E005', 'Indah Kholidah', 'Perempuan', 'Tuban', '1990-09-10', 1, 5, 5),
(6, 'E006', 'Mala', 'Perempuan', 'Tuban', '1990-09-10', 1, 5, 5),
(7, 'E007', 'Cila', 'Perempuan', 'Tuban', '2001-09-27', 2, 5, 5),
(8, 'E008', 'Cil', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 5),
(9, 'E009', 'Akmal', 'Laki-Laki', 'Tuban', '2001-09-27', 1, 6, 1),
(13, 'E013', 'Akma', 'Laki-Laki', 'Tuban', '2001-09-27', 1, 6, 1),
(15, 'E015', 'Acil', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(18, 'E018', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(20, 'E020', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(21, 'E021', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 4),
(22, 'E022', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(23, 'E023', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(24, 'E024', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(25, 'E025', 'Aqilah', 'Perempuan', 'Tuban', '2024-10-01', 1, 1, 1),
(26, 'E026', 'Aqilah', 'Perempuan', 'Tuban', '2024-10-01', 1, 2, 3),
(27, '2410014', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1),
(30, '241003753', 'Aqilah Akmalia', 'Perempuan', 'Tuban', '2001-09-27', 1, 6, 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `employmentstatuses`
--

CREATE TABLE `employmentstatuses` (
  `Id` int(11) NOT NULL,
  `Status` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `employmentstatuses`
--

INSERT INTO `employmentstatuses` (`Id`, `Status`) VALUES
(1, 'Tetap'),
(2, 'Kontrak');

-- --------------------------------------------------------

--
-- Struktur dari tabel `positions`
--

CREATE TABLE `positions` (
  `Id` int(11) NOT NULL,
  `PositionName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `positions`
--

INSERT INTO `positions` (`Id`, `PositionName`) VALUES
(1, 'Developer'),
(2, 'Manager'),
(3, 'Asisten Manager'),
(4, 'Analyst'),
(5, 'Staff');

-- --------------------------------------------------------

--
-- Struktur dari tabel `workunits`
--

CREATE TABLE `workunits` (
  `Id` int(11) NOT NULL,
  `UnitName` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data untuk tabel `workunits`
--

INSERT INTO `workunits` (`Id`, `UnitName`) VALUES
(1, 'Keuangan'),
(2, 'HRD'),
(3, 'Pemasaran'),
(4, 'Produksi'),
(5, 'Umum'),
(6, 'IT');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `employeehistory`
--
ALTER TABLE `employeehistory`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `EmployeeId` (`EmployeeId`),
  ADD KEY `EmploymentStatusId` (`EmploymentStatusId`),
  ADD KEY `WorkUnitId` (`WorkUnitId`),
  ADD KEY `PositionId` (`PositionId`);

--
-- Indeks untuk tabel `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `EmploymentStatusId` (`EmploymentStatusId`),
  ADD KEY `WorkUnitId` (`WorkUnitId`),
  ADD KEY `PositionId` (`PositionId`);

--
-- Indeks untuk tabel `employmentstatuses`
--
ALTER TABLE `employmentstatuses`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks untuk tabel `positions`
--
ALTER TABLE `positions`
  ADD PRIMARY KEY (`Id`);

--
-- Indeks untuk tabel `workunits`
--
ALTER TABLE `workunits`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `employeehistory`
--
ALTER TABLE `employeehistory`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=47;

--
-- AUTO_INCREMENT untuk tabel `employees`
--
ALTER TABLE `employees`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=32;

--
-- AUTO_INCREMENT untuk tabel `employmentstatuses`
--
ALTER TABLE `employmentstatuses`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT untuk tabel `positions`
--
ALTER TABLE `positions`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT untuk tabel `workunits`
--
ALTER TABLE `workunits`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `employeehistory`
--
ALTER TABLE `employeehistory`
  ADD CONSTRAINT `employeehistory_ibfk_1` FOREIGN KEY (`EmployeeId`) REFERENCES `employees` (`Id`),
  ADD CONSTRAINT `employeehistory_ibfk_2` FOREIGN KEY (`EmploymentStatusId`) REFERENCES `employmentstatuses` (`Id`),
  ADD CONSTRAINT `employeehistory_ibfk_3` FOREIGN KEY (`WorkUnitId`) REFERENCES `workunits` (`Id`),
  ADD CONSTRAINT `employeehistory_ibfk_4` FOREIGN KEY (`PositionId`) REFERENCES `positions` (`Id`);

--
-- Ketidakleluasaan untuk tabel `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`EmploymentStatusId`) REFERENCES `employmentstatuses` (`Id`),
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`WorkUnitId`) REFERENCES `workunits` (`Id`),
  ADD CONSTRAINT `employees_ibfk_3` FOREIGN KEY (`PositionId`) REFERENCES `positions` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
