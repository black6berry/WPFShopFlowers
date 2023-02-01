-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Хост: localhost
-- Время создания: Янв 26 2023 г., 18:17
-- Версия сервера: 5.7.27-30
-- Версия PHP: 7.1.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `u1838417_shop_flowers`
--

-- --------------------------------------------------------

--
-- Структура таблицы `address`
--

CREATE TABLE `address` (
  `address_id` int(11) NOT NULL,
  `country` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `street` varchar(50) NOT NULL,
  `home` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `address`
--

INSERT INTO `address` (`address_id`, `country`, `city`, `street`, `home`) VALUES
(1, 'Россия', 'Москва', 'ул. Чайкина', '13'),
(2, 'Россия', 'Москва', 'ул. Пушкина', '10'),
(3, 'Беларусь', 'Брест', 'ул. Армейская', '23'),
(4, 'Беларусь', 'Минск', 'ул. Бабушкина', '25');

-- --------------------------------------------------------

--
-- Структура таблицы `flower`
--

CREATE TABLE `flower` (
  `flower_id` int(11) NOT NULL,
  `flower_name` varchar(50) NOT NULL,
  `flower_category` varchar(50) NOT NULL,
  `country` varchar(50) NOT NULL,
  `flowering_season` varchar(50) NOT NULL,
  `sort` varchar(50) NOT NULL,
  `price` float(5,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `flower`
--

INSERT INTO `flower` (`flower_id`, `flower_name`, `flower_category`, `country`, `flowering_season`, `sort`, `price`) VALUES
(1, 'Хризантема кустовая', 'Индийская', 'Беларусь', 'Лето', 'Селебрейт', 120.00),
(2, 'Хризантема кустовая', 'Индийская', 'Беларусь', 'Лето', 'Оптимист', 150.00),
(4, 'Роза', 'Дикорастущая', 'Эквадор', 'Лето', 'Шиповник', 90.00),
(5, 'Роза', 'Современная', 'Эквадор', 'Лето', 'Мускусный', 125.00);

-- --------------------------------------------------------

--
-- Структура таблицы `order`
--

CREATE TABLE `order` (
  `order_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `payment_type_id` int(11) NOT NULL,
  `date` datetime NOT NULL,
  `total cost` float(10,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `payment_type`
--

CREATE TABLE `payment_type` (
  `payment_type_id` int(11) NOT NULL,
  `type_name` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Дамп данных таблицы `payment_type`
--

INSERT INTO `payment_type` (`payment_type_id`, `type_name`) VALUES
(1, 'Наличные'),
(2, 'Картой');

-- --------------------------------------------------------

--
-- Структура таблицы `product_order`
--

CREATE TABLE `product_order` (
  `product_order _id` int(11) NOT NULL,
  `order_id` int(11) NOT NULL,
  `flower_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Структура таблицы `product_supplier`
--

CREATE TABLE `product_supplier` (
  `product_supplier_id` int(11) NOT NULL,
  `FIO` varchar(50) NOT NULL,
  `household_type` varchar(20) NOT NULL,
  `address_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_supplier`
--

INSERT INTO `product_supplier` (`product_supplier_id`, `FIO`, `household_type`, `address_id`) VALUES
(1, 'Цветков Даниил Игоревич', 'Промышленная теплица', 1),
(2, 'Эльбрус Евгений Дмитреевич', 'Сад', 2);

-- --------------------------------------------------------

--
-- Структура таблицы `product_supplier_flower`
--

CREATE TABLE `product_supplier_flower` (
  `product_supplier_flower_id` int(11) NOT NULL,
  `product_supplier` int(11) NOT NULL,
  `flower_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `product_supplier_flower`
--

INSERT INTO `product_supplier_flower` (`product_supplier_flower_id`, `product_supplier`, `flower_id`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 2, 4),
(4, 2, 5);

-- --------------------------------------------------------

--
-- Структура таблицы `rolesm`
--

CREATE TABLE `rolesm` (
  `id` int(255) NOT NULL,
  `name` varchar(222) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `rolesm`
--

INSERT INTO `rolesm` (`id`, `name`) VALUES
(1, 'Admin'),
(2, 'User'),
(4, 'Florist');

-- --------------------------------------------------------

--
-- Структура таблицы `usersm`
--

CREATE TABLE `usersm` (
  `id` int(11) NOT NULL,
  `name` varchar(50) NOT NULL,
  `email` varchar(50) DEFAULT NULL,
  `password` varchar(50) NOT NULL,
  `rolesm_id` int(11) NOT NULL,
  `login` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `usersm`
--

INSERT INTO `usersm` (`id`, `name`, `email`, `password`, `rolesm_id`, `login`) VALUES
(1, 'Nik', NULL, '111', 1, '121'),
(11, 'Mari', NULL, '1', 1, '1'),
(12, 'Tim', 'tim@1.ru', '2', 2, '2'),
(14, 'Sergey', '', '3', 2, '3');

-- --------------------------------------------------------

--
-- Структура таблицы `user_address`
--

CREATE TABLE `user_address` (
  `user_address_id` int(11) NOT NULL,
  `usersm_id` int(11) NOT NULL,
  `address_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `user_address`
--

INSERT INTO `user_address` (`user_address_id`, `usersm_id`, `address_id`) VALUES
(2, 1, 1),
(3, 11, 2),
(1, 11, 3);

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `address`
--
ALTER TABLE `address`
  ADD PRIMARY KEY (`address_id`);

--
-- Индексы таблицы `flower`
--
ALTER TABLE `flower`
  ADD PRIMARY KEY (`flower_id`);

--
-- Индексы таблицы `order`
--
ALTER TABLE `order`
  ADD PRIMARY KEY (`order_id`),
  ADD KEY `payment_type_id` (`payment_type_id`),
  ADD KEY `user_id` (`user_id`);

--
-- Индексы таблицы `payment_type`
--
ALTER TABLE `payment_type`
  ADD PRIMARY KEY (`payment_type_id`);

--
-- Индексы таблицы `product_order`
--
ALTER TABLE `product_order`
  ADD PRIMARY KEY (`product_order _id`),
  ADD KEY `order_id` (`order_id`);

--
-- Индексы таблицы `product_supplier`
--
ALTER TABLE `product_supplier`
  ADD PRIMARY KEY (`product_supplier_id`),
  ADD KEY `address_id` (`address_id`);

--
-- Индексы таблицы `product_supplier_flower`
--
ALTER TABLE `product_supplier_flower`
  ADD PRIMARY KEY (`product_supplier_flower_id`),
  ADD KEY `product_supplier` (`product_supplier`,`flower_id`),
  ADD KEY `flower_id` (`flower_id`);

--
-- Индексы таблицы `rolesm`
--
ALTER TABLE `rolesm`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `usersm`
--
ALTER TABLE `usersm`
  ADD PRIMARY KEY (`id`),
  ADD KEY `rolesm` (`rolesm_id`);

--
-- Индексы таблицы `user_address`
--
ALTER TABLE `user_address`
  ADD PRIMARY KEY (`user_address_id`),
  ADD KEY `usersm_id` (`usersm_id`,`address_id`),
  ADD KEY `address_id` (`address_id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `address`
--
ALTER TABLE `address`
  MODIFY `address_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `flower`
--
ALTER TABLE `flower`
  MODIFY `flower_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT для таблицы `order`
--
ALTER TABLE `order`
  MODIFY `order_id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `payment_type`
--
ALTER TABLE `payment_type`
  MODIFY `payment_type_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `product_order`
--
ALTER TABLE `product_order`
  MODIFY `product_order _id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT для таблицы `product_supplier`
--
ALTER TABLE `product_supplier`
  MODIFY `product_supplier_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT для таблицы `product_supplier_flower`
--
ALTER TABLE `product_supplier_flower`
  MODIFY `product_supplier_flower_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `rolesm`
--
ALTER TABLE `rolesm`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `usersm`
--
ALTER TABLE `usersm`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT для таблицы `user_address`
--
ALTER TABLE `user_address`
  MODIFY `user_address_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `order`
--
ALTER TABLE `order`
  ADD CONSTRAINT `order_ibfk_1` FOREIGN KEY (`payment_type_id`) REFERENCES `payment_type` (`payment_type_id`),
  ADD CONSTRAINT `order_ibfk_4` FOREIGN KEY (`user_id`) REFERENCES `usersm` (`id`);

--
-- Ограничения внешнего ключа таблицы `product_order`
--
ALTER TABLE `product_order`
  ADD CONSTRAINT `product_order_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `order` (`order_id`);

--
-- Ограничения внешнего ключа таблицы `product_supplier`
--
ALTER TABLE `product_supplier`
  ADD CONSTRAINT `product_supplier_ibfk_1` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`);

--
-- Ограничения внешнего ключа таблицы `product_supplier_flower`
--
ALTER TABLE `product_supplier_flower`
  ADD CONSTRAINT `product_supplier_flower_ibfk_1` FOREIGN KEY (`product_supplier`) REFERENCES `product_supplier` (`product_supplier_id`),
  ADD CONSTRAINT `product_supplier_flower_ibfk_2` FOREIGN KEY (`flower_id`) REFERENCES `flower` (`flower_id`);

--
-- Ограничения внешнего ключа таблицы `usersm`
--
ALTER TABLE `usersm`
  ADD CONSTRAINT `usersm_ibfk_2` FOREIGN KEY (`rolesm_id`) REFERENCES `rolesm` (`id`);

--
-- Ограничения внешнего ключа таблицы `user_address`
--
ALTER TABLE `user_address`
  ADD CONSTRAINT `user_address_ibfk_1` FOREIGN KEY (`address_id`) REFERENCES `address` (`address_id`),
  ADD CONSTRAINT `user_address_ibfk_2` FOREIGN KEY (`usersm_id`) REFERENCES `usersm` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
