/** COMPUTER MANUFACTURER **/
INSERT INTO computer_manufacturer (name, serial_regex) VALUES ('Apple', '^[A-Z]{3}[C-Z0-9][1-9C-NP-RTY][A-Z0-9]{3}[A-Z0-9]{4}$');
INSERT INTO computer_manufacturer (name, serial_regex) VALUES ('Dell', '^[A-Z0-9]{7}$');
INSERT INTO computer_manufacturer (name, serial_regex) VALUES ('HP', '^[A-Z0-9]{3}\d{3}[A-Z0-9]{4}$');
INSERT INTO computer_manufacturer (name, serial_regex) VALUES ('Lenovo', '^\d{2}-[A-Z0-9]{5}$');


/** COMPUTER STATUS
1. New - The laptop is brand new and has not been assigned or used.
2. In Use - The laptop is currently assigned to and being used by someone.
3. Available - The laptop is ready for use but not currently assigned to anyone. (However it was at least assigned one time)
4. In Maintenance - The laptop is undergoing repairs or maintenance.
5. Retired - The laptop has been decommissioned and is no longer in service.
**/
INSERT INTO computer_status (localized_name) VALUES ('new');
INSERT INTO computer_status (localized_name) VALUES ('in_use');
INSERT INTO computer_status (localized_name) VALUES ('available');
INSERT INTO computer_status (localized_name) VALUES ('in_maintenance');
INSERT INTO computer_status (localized_name) VALUES ('retired');


/** COMPUTER **/
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '1ON9S3H', 'Name: Dell XPS 13 Plus<br>CPU: Intel Core i7-1260P<br>RAM: 16GB<br>Display: 13.4 OLED 4K', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-19 20:24:35', '2024-02-15 20:24:35', '2023-08-20 00:24:35');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, 'R2Z8134R9W', 'Name: HP Elite Dragonfly G4<br><br>CPU: Intel Core i7-1365U<br>GPU: Intel Iris Xe<br>RAM: 16GB<br>Storage: 512GB SSD<br>Display: 13.5 - inch, 1920 x 1280<br>Weight: 2.2 lbs<br>Best for: Executives on the go.', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-20 04:14:26', '2024-02-16 04:14:26', '2023-08-20 07:14:26');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, 'DZ2655ILYB', 'Name: HP Spectre x360 14<br>CPU: Intel Core i7 - 1355U(13th Gen)<br>GPU: Intel Iris Xe Graphics<br>RAM: 16GB<br>Storage: 1TB SSD<br>Display: 13.5 - inch, 1920 x 1280 OLED touch<br>Weight: 3.01 lbs<br>Battery Life: Up to 10 hours<br>Best for: Premium design and 2-in-1 functionality.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-20 03:46:00', '2024-02-16 03:46:00', '2023-08-20 07:46:00');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'H613M30', 'Name: Dell Inspiron 14 2-in-1<br>CPU: Intel i7-1355U<br>RAM: 16GB<br>Display: 14 FHD+', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-19 23:26:49', '2024-02-15 23:26:49', '2023-08-20 09:26:49');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'ZEK0NR2', 'Name: Dell XPS 15 (2024)<br>CPU: Intel Core i9-13900H<br>GPU: NVIDIA GeForce RTX 4060<br>RAM: Up to 32GB<br>Display: 15.6 OLED 3.5K', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-20 01:30:08', '2024-02-16 01:30:08', '2023-08-20 13:30:08');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'ZLZ0PMNJ9YDI', 'Name: MacBook Pro 16 (2023)<br>Chip: Apple M2 Max<br>RAM: Up to 96GB<br>Storage: Up to 8TB SSD<br>Display: 16.2 Liquid Retina XDR', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-20 09:44:57', '2024-02-16 09:44:57', '2023-08-20 14:44:57');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '3H4116D', 'Name: Alienware x14 R2<br>CPU: Intel Core i9-13900H<br>GPU: NVIDIA RTX 4070<br>Display: 14 FHD 144Hz', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-20 12:30:27', '2024-02-16 12:30:27', '2023-08-20 16:30:27');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '6438BSL', 'Name: Alienware x14 R2<br>CPU: Intel Core i9-13900H<br>GPU: NVIDIA RTX 4070<br>Display: 14 FHD 144Hz', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-20 15:46:41', '2024-02-16 15:46:41', '2023-08-20 23:46:41');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, 'Q541591923', 'Name: HP ZBook Studio G9<br>CPU: Intel Core i9-12950HX<br>GPU: NVIDIA RTX A5500<br>RAM: 64GB<br>Storage: 2TB SSD<br>Display: 16 - inch, UHD +<br>Weight: 4.41 lbs<br>Best for: Creative professionals.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-20 16:58:20', '2024-02-16 16:58:20', '2023-08-21 04:58:20');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'VCC3T617HEX6', 'Name: MacBook Pro 14 (2023)<br>Chip: Apple M2 Pro<br>RAM: Up to 64GB<br>Storage: Up to 8TB SSD<br>Display: 14.2 Liquid Retina XDR', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-21 06:48:40', '2024-02-17 06:48:40', '2023-08-21 08:48:40');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'SVFL8ODBGT0K', 'Name: MacBook Pro 16 (2023)<br>Chip: Apple M2 Max<br>RAM: Up to 96GB<br>Storage: Up to 8TB SSD<br>Display: 16.2 Liquid Retina XDR', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-21 01:34:39', '2024-02-17 01:34:39', '2023-08-21 10:34:39');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'L267OOG', 'Name: Dell XPS 15 (2024)<br>CPU: Intel Core i9-13900H<br>GPU: NVIDIA GeForce RTX 4060<br>RAM: Up to 32GB<br>Display: 15.6 OLED 3.5K', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-22 01:50:16', '2024-02-18 01:50:16', '2023-08-22 08:50:16');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '43FD196', 'Name: Dell XPS 17<br>CPU: Intel Core i9-13900H<br>GPU: NVIDIA RTX 4080<br>Display: 17 UHD+ (4K)', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-22 01:31:27', '2024-02-18 01:31:27', '2023-08-22 12:31:27');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'SXSE7TW08S34', 'Name: MacBook Air 15 (2023)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 15.3 Liquid Retina', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-22 13:47:41', '2024-02-18 13:47:41', '2023-08-22 15:47:41');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'NND0J8E3TCN7', 'Name: MacBook Air 15 (2023)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 15.3 Liquid Retina', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-22 16:23:56', '2024-02-18 16:23:56', '2023-08-23 00:23:56');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '39BV4WI', 'Name: Dell XPS 13 (2024)<br>CPU: Qualcomm Snapdragon X Elite<br>RAM: 16GB<br>Display: 13.3 FHD+', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-23 21:53:16', '2024-02-19 21:53:16', '2023-08-24 06:53:16');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '0GH9ARE', 'Name: Dell XPS 13 Plus<br>CPU: Intel Core i7-1260P<br>RAM: 16GB<br>Display: 13.4 OLED 4K', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-24 01:18:27', '2024-02-20 01:18:27', '2023-08-24 12:18:27');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, '6Q4367TI85', 'Name: HP Omen 17 (2024)<br>CPU: Intel Core i9-13900HX<br>GPU: NVIDIA RTX 4080<br>RAM: 32GB DDR5<br>Storage: 1TB SSD<br>Display: 17.3 - inch, QHD 165Hz<br>Weight: 6.15 lbs<br>Best for: High - end gaming.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-24 17:38:30', '2024-02-20 17:38:30', '2023-08-25 00:38:30');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'L02RWQ8', 'Name: Dell G15 (2024)<br>CPU: Intel Core i7-13650HX<br>GPU: NVIDIA RTX 4060<br>Display: 15.6, 165Hz', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-24 19:04:57', '2024-02-20 19:04:57', '2023-08-25 03:04:57');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'K08HG60', 'Name: Dell Inspiron 14 2-in-1<br>CPU: Intel i7-1355U<br>RAM: 16GB<br>Display: 14 FHD+', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-25 07:08:50', '2024-02-21 07:08:50', '2023-08-25 10:08:50');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '8B5VP47', 'Name: Alienware m18 AMD Gaming<br>CPU: AMD Ryzen 9 7845HX<br>GPU: NVIDIA RTX 4080<br>Display: 18, 480Hz<br>RAM: 32GB DDR5', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-25 15:51:37', '2024-02-21 15:51:37', '2023-08-25 22:51:37');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, '3WG491KPPB', 'Name: HP Spectre x360 14<br>CPU: Intel Core i7 - 1355U(13th Gen)<br>GPU: Intel Iris Xe Graphics<br>RAM: 16GB<br>Storage: 1TB SSD<br>Display: 13.5 - inch, 1920 x 1280 OLED touch<br>Weight: 3.01 lbs<br>Battery Life: Up to 10 hours<br>Best for: Premium design and 2-in-1 functionality.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-25 14:34:48', '2024-02-21 14:34:48', '2023-08-26 00:34:48');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, '9U2636D6LR', 'Name: HP Pavilion Plus 14<br>CPU: Intel Core i7-12700H<br>GPU: Intel Iris Xe<br>RAM: 16GB<br>Storage: 1TB SSD<br>Display: 14 - inch, 2880 x 1800 OLED<br>Weight: 3.09 lbs<br>Best for: Budget - friendly, powerful performance.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-26 02:07:55', '2024-02-22 02:07:55', '2023-08-26 05:07:55');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'ZTQ5A4V', 'Name: Dell Inspiron 14 2-in-1<br>CPU: Intel i7-1355U<br>RAM: 16GB<br>Display: 14 FHD+', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-26 06:29:45', '2024-02-22 06:29:45', '2023-08-26 07:29:45');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'EKI5Y8VYD283', 'Name: MacBook Air 13 (2023)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 13.6 Liquid Retina', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-26 09:48:28', '2024-02-22 09:48:28', '2023-08-26 17:48:28');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, '421570M75N', 'Name: HP EliteBook 840 G10<br>CPU: Intel Core i7-1365U<br>GPU: Intel Iris Xe<br>RAM: 16GB<br>Storage: 1TB SSD<br>Display: 14 - inch, 1080p<br>Weight: 2.95 lbs<br>Best for: Business professionals with security needs.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-26 16:45:23', '2024-02-22 16:45:23', '2023-08-26 20:45:23');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'ZCM8T71K8411', 'Name: MacBook Pro 16 (2023)<br>Chip: Apple M2 Max<br>RAM: Up to 96GB<br>Storage: Up to 8TB SSD<br>Display: 16.2 Liquid Retina XDR', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-26 13:59:55', '2024-02-22 13:59:55', '2023-08-26 22:59:55');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'JVMU64P5V1VT', 'Name: MacBook Air 15 (2023)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 15.3 Liquid Retina', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-27 02:51:28', '2024-02-23 02:51:28', '2023-08-27 08:51:28');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (4, '55-4C696', 'Name: Lenovo Yoga Pro 9i 16<br>Specs: Intel Core i9 processor, NVIDIA RTX 4070 GPU, 16-inch Mini LED display with 165Hz refresh rate<br>Key Features: Outstanding display, powerful creative and gaming performance, bright Mini LED screen, and 1TB storage.<br>Drawbacks: Heavy (2.23 kg) and limited battery life (6 hours).<br>Recommendation: Ideal for high-end gaming and professional creative tasks.', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-27 09:02:19', '2024-02-23 09:02:19', '2023-08-27 15:02:19');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '0DTDK3C', 'Name: Dell Inspiron 14 2-in-1<br>CPU: Intel i7-1355U<br>RAM: 16GB<br>Display: 14 FHD+', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-28 04:45:47', '2024-02-24 04:45:47', '2023-08-28 06:45:47');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '0YJ017E', 'Name: Dell XPS 13 (2024)<br>CPU: Qualcomm Snapdragon X Elite<br>RAM: 16GB<br>Display: 13.3 FHD+', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-27 23:19:33', '2024-02-23 23:19:33', '2023-08-28 07:19:33');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, 'J20326A', 'Name: Dell XPS 13 Plus<br>CPU: Intel Core i7-1260P<br>RAM: 16GB<br>Display: 13.4 OLED 4K', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-28 06:40:25', '2024-02-24 06:40:25', '2023-08-28 07:40:25');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'RZL2THUS8V34', 'Name: MacBook Pro 13 (2022)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 13.3 Retina', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-28 02:47:16', '2024-02-24 02:47:16', '2023-08-28 07:47:16');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'SNXU4CECTR7Z', 'Name: MacBook Air 13 (2023)<br>Chip: Apple M2<br>RAM: Up to 24GB<br>Storage: Up to 2TB SSD<br>Display: 13.6 Liquid Retina', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-29 14:55:31', '2024-02-25 14:55:31', '2023-08-29 16:55:31');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '7B832MK', 'Name: Dell Inspiron 14 2-in-1<br>CPU: Intel i7-1355U<br>RAM: 16GB<br>Display: 14 FHD+', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-29 15:27:51', '2024-02-25 15:27:51', '2023-08-29 17:27:51');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (3, 'P1S9054EWW', 'Name: HP Dragonfly Pro Chromebook<br>CPU: Intel Core i5-1235U<br>GPU: Intel Iris Xe<br>RAM: 16GB<br>Storage: 256GB SSD<br>Display: 14 - inch, 2560 x 1600<br>Weight: 3.33 lbs<br>Best for: Chromebook enthusiasts with premium needs.', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-30 02:18:18', '2024-02-26 02:18:18', '2023-08-30 03:18:18');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (2, '2R6Y6ZF', 'Name: Dell XPS 13 Plus<br>CPU: Intel Core i7-1260P<br>RAM: 16GB<br>Display: 13.4 OLED 4K', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-30 00:43:13', '2024-02-26 00:43:13', '2023-08-30 10:43:13');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (4, '24-GY718', 'Name: Lenovo ThinkPad X1 Carbon Gen 11<br>Specs: Intel 13th Gen Core i7 processor, up to 32GB RAM, 1TB SSD, 14-inch 2.8k OLED display<br>Key Features: Lightweight design, excellent keyboard, strong build, and biometric security features.<br>Recommendation: Ideal for business professionals needing portability and reliable performance.', 'https://netdna.coolthings.com/wp-content/uploads/2024/02/the-best-laptops-for-photo-editing-08-Dell-XPS-15-9530.jpg', '2023-08-30 05:11:32', '2024-02-26 05:11:32', '2023-08-30 11:11:32');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'VUW4THT57L09', 'Name: MacBook Pro 16 (2023)<br>Chip: Apple M2 Max<br>RAM: Up to 96GB<br>Storage: Up to 8TB SSD<br>Display: 16.2 Liquid Retina XDR', 'https://www.digitaltrends.com/wp-content/uploads/2022/08/Dell-XPS-17-with-RTX-3060-and-NVIDIA-Studio.jpg', '2023-08-30 19:51:45', '2024-02-26 19:51:45', '2023-08-30 23:51:45');
INSERT INTO computer (computer_manufacturer_id, serial_number, specifications, image_url, purchase_dt, warranty_expiration_dt, create_dt) VALUES (1, 'WGODQ5TXEEI1', 'Name: MacBook Pro 16 (2023)<br>Chip: Apple M2 Max<br>RAM: Up to 96GB<br>Storage: Up to 8TB SSD<br>Display: 16.2 Liquid Retina XDR', 'https://photographylife.com/wp-content/uploads/2023/02/XPS15.jpg', '2023-08-30 21:53:00', '2024-02-26 21:53:00', '2023-08-31 03:53:00');


/* USER */
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Amina', 'Wade', 'amina.wade@gmail.com', '2023-08-16 22:36:28');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Jake', 'Mitchell', 'jake.mitchell@gmail.com', '2023-08-17 21:26:20');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Willow', 'Hull', 'willow.hull@gmail.com', '2023-08-17 14:48:47');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Salem', 'Blackwell', 'salem.blackwell@gmail.com', '2023-08-18 06:27:41');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Saoirse', 'Wiley', 'saoirse.wiley@gmail.com', '2023-08-19 03:35:49');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Mathew', 'Giles', 'mathew.giles@gmail.com', '2023-08-17 11:45:59');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Bailee', 'Underwood', 'bailee.underwood@gmail.com', '2023-08-18 10:13:54');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Reece', 'Wyatt', 'reece.wyatt@gmail.com', '2023-08-17 18:57:20');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Liberty', 'Schaefer', 'liberty.schaefer@gmail.com', '2023-08-19 22:13:30');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Ishaan', 'Leblanc', 'ishaan.leblanc@gmail.com', '2023-08-18 15:38:42');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Novalee', 'Conley', 'novalee.conley@gmail.com', '2023-08-19 08:07:42');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Marvin', 'Murillo', 'marvin.murillo@gmail.com', '2023-08-20 17:56:10');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Mikaela', 'McKinney', 'mikaela.mckinney@gmail.com', '2023-08-19 21:59:37');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Romeo', 'Cooper', 'romeo.cooper@gmail.com', '2023-08-20 23:52:13');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Serenity', 'Corona', 'serenity.corona@gmail.com', '2023-08-19 17:04:32');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Darian', 'Clarke', 'darian.clarke@gmail.com', '2023-08-21 12:14:50');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Kaitlyn', 'Moon', 'kaitlyn.moon@gmail.com', '2023-08-22 07:13:46');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Nova', 'Beil', 'nova.beil@gmail.com', '2023-08-24 05:32:05');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Itzel', 'Berger', 'itzel.berger@gmail.com', '2023-08-24 04:55:26');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Byron', 'Nicholson', 'byron.nicholson@gmail.com', '2023-08-22 22:23:06');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Justice', 'Morse', 'justice.morse@gmail.com', '2023-08-24 16:08:30');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Bode', 'Savage', 'bode.savage@gmail.com', '2023-08-23 02:22:54');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Louise', 'Boyer', 'louise.boyer@gmail.com', '2023-08-24 19:36:09');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Zeke', 'Colon', 'zeke.colon@gmail.com', '2023-08-24 17:01:21');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Remy', 'Herrera', 'remy.herrera@gmail.com', '2023-08-23 14:50:23');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('River', 'Holloway', 'river.holloway@gmail.com', '2023-08-25 13:26:05');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Mae', 'Schaefer', 'mae.schaefer@gmail.com', '2023-08-23 23:50:56');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Ishaan', 'Pitts', 'ishaan.pitts@gmail.com', '2023-08-26 08:01:21');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Nala', 'Pena', 'nala.pena@gmail.com', '2023-08-25 22:19:36');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Marcus', 'Mayer', 'marcus.mayer@gmail.com', '2023-08-26 10:44:58');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Ainhoa', 'Shepherd', 'ainhoa.shepherd@gmail.com', '2023-08-26 08:06:32');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Ronald', 'Savage', 'ronald.savage@gmail.com', '2023-08-25 07:13:34');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Louise', 'Cunningham', 'louise.cunningham@gmail.com', '2023-08-26 21:28:38');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Alejandro', 'Reynolds', 'alejandro.reynolds@gmail.com', '2023-08-28 17:53:30');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Isabelle', 'Davenport', 'isabelle.davenport@gmail.com', '2023-08-27 18:28:22');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Dariel', 'Little', 'dariel.little@gmail.com', '2023-08-28 14:12:17');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Harley', 'Solomon', 'harley.solomon@gmail.com', '2023-08-27 03:02:30');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Musa', 'Hahn', 'musa.hahn@gmail.com', '2023-08-29 00:58:14');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Fallon', 'Cisneros', 'fallon.cisneros@gmail.com', '2023-08-28 03:29:31');
INSERT INTO user (first_name, last_name, email_address, create_dt) VALUES ('Alden', 'Long', 'alden.long@gmail.com', '2023-08-30 07:14:39');


/* lnk_computer_computer_status (new) */
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (1, 1, '2023-08-20 00:24:35');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (2, 1, '2023-08-20 07:14:26');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (3, 1, '2023-08-20 07:46:00');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (4, 1, '2023-08-20 09:26:49');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (5, 1, '2023-08-20 13:30:08');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (6, 1, '2023-08-20 14:44:57');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (7, 1, '2023-08-20 16:30:27');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (8, 1, '2023-08-20 23:46:41');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (9, 1, '2023-08-21 04:58:20');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (10, 1, '2023-08-21 08:48:40');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (11, 1, '2023-08-21 10:34:39');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (12, 1, '2023-08-22 08:50:16');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (13, 1, '2023-08-22 12:31:27');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (14, 1, '2023-08-22 15:47:41');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (15, 1, '2023-08-23 00:23:56');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (16, 1, '2023-08-24 06:53:16');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (17, 1, '2023-08-24 12:18:27');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (18, 1, '2023-08-25 00:38:30');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (19, 1, '2023-08-25 03:04:57');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (20, 1, '2023-08-25 10:08:50');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (21, 1, '2023-08-25 22:51:37');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (22, 1, '2023-08-26 00:34:48');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (23, 1, '2023-08-26 05:07:55');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (24, 1, '2023-08-26 07:29:45');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (25, 1, '2023-08-26 17:48:28');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (26, 1, '2023-08-26 20:45:23');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (27, 1, '2023-08-26 22:59:55');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (28, 1, '2023-08-27 08:51:28');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (29, 1, '2023-08-27 15:02:19');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (30, 1, '2023-08-28 06:45:47');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (31, 1, '2023-08-28 07:19:33');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (32, 1, '2023-08-28 07:40:25');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (33, 1, '2023-08-28 07:47:16');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (34, 1, '2023-08-29 16:55:31');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (35, 1, '2023-08-29 17:27:51');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (36, 1, '2023-08-30 03:18:18');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (37, 1, '2023-08-30 10:43:13');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (38, 1, '2023-08-30 11:11:32');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (39, 1, '2023-08-30 23:51:45');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (40, 1, '2023-08-31 03:53:00');


/* lnk_computer_computer_status (in_use) */
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (1, 2, '2023-08-20 00:53:26');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (2, 2, '2023-08-20 08:09:23');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (3, 2, '2023-08-20 08:57:20');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (4, 2, '2023-08-20 10:48:26');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (5, 2, '2023-08-20 14:58:55');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (6, 2, '2023-08-20 16:05:10');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (7, 2, '2023-08-20 17:03:26');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (8, 2, '2023-08-21 00:01:58');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (9, 2, '2023-08-21 06:51:16');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (10, 2, '2023-08-21 09:47:01');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (11, 2, '2023-08-21 11:17:51');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (12, 2, '2023-08-22 10:16:58');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (13, 2, '2023-08-22 13:50:32');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (14, 2, '2023-08-22 16:04:47');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (15, 2, '2023-08-23 02:12:11');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (16, 2, '2023-08-24 08:01:55');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (17, 2, '2023-08-24 13:56:42');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (18, 2, '2023-08-25 01:55:48');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (19, 2, '2023-08-25 03:41:20');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (20, 2, '2023-08-25 10:44:34');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (21, 2, '2023-08-25 23:25:39');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (22, 2, '2023-08-26 02:15:26');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (23, 2, '2023-08-26 06:17:20');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (24, 2, '2023-08-26 08:52:53');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (25, 2, '2023-08-26 18:39:55');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (26, 2, '2023-08-26 22:23:30');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (27, 2, '2023-08-26 23:26:38');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (28, 2, '2023-08-27 09:48:18');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (29, 2, '2023-08-27 16:13:34');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (30, 2, '2023-08-28 08:10:47');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (31, 2, '2023-08-28 07:39:07');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (32, 2, '2023-08-28 08:46:59');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (33, 2, '2023-08-28 09:01:54');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (34, 2, '2023-08-29 17:27:24');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (35, 2, '2023-08-29 19:18:07');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (36, 2, '2023-08-30 04:34:13');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (37, 2, '2023-08-30 12:22:28');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (38, 2, '2023-08-30 13:09:16');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (39, 2, '2023-08-31 01:20:40');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (40, 2, '2023-08-31 04:19:22');


/* lnk_computer_computer_status (in_maintenance) */
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (1, 4, '2023-09-09 20:55:21');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (4, 4, '2023-09-04 20:53:53');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (10, 4, '2023-09-07 22:51:39');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (14, 4, '2023-09-14 17:28:23');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (20, 4, '2023-09-08 22:13:24');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (28, 4, '2023-09-21 06:37:27');
INSERT INTO lnk_computer_computer_status (computer_id, computer_status_id, assign_dt) VALUES (38, 4, '2023-09-19 08:06:01');


/* lnk_computer_user */
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (1, 1, '2023-08-20 00:53:26', '2023-09-09 20:55:21');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (2, 2, '2023-08-20 08:09:23');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (3, 3, '2023-08-20 08:57:20');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (4, 4, '2023-08-20 10:48:26', '2023-09-04 20:53:53');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (5, 5, '2023-08-20 14:58:55');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (6, 6, '2023-08-20 16:05:10');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (7, 7, '2023-08-20 17:03:26');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (8, 8, '2023-08-21 00:01:58');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (9, 9, '2023-08-21 06:51:16');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (10, 10, '2023-08-21 09:47:01', '2023-09-07 22:51:39');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (11, 11, '2023-08-21 11:17:51');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (12, 12, '2023-08-22 10:16:58');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (13, 13, '2023-08-22 13:50:32');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (14, 14, '2023-08-22 16:04:47', '2023-09-14 17:28:23');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (15, 15, '2023-08-23 02:12:11');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (16, 16, '2023-08-24 08:01:55');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (17, 17, '2023-08-24 13:56:42');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (18, 18, '2023-08-25 01:55:48');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (19, 19, '2023-08-25 03:41:20');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (20, 20, '2023-08-25 10:44:34', '2023-09-08 22:13:24');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (21, 21, '2023-08-25 23:25:39');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (22, 22, '2023-08-26 02:15:26');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (23, 23, '2023-08-26 06:17:20');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (24, 24, '2023-08-26 08:52:53');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (25, 25, '2023-08-26 18:39:55');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (26, 26, '2023-08-26 22:23:30');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (27, 27, '2023-08-26 23:26:38');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (28, 28, '2023-08-27 09:48:18', '2023-09-21 06:37:27');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (29, 29, '2023-08-27 16:13:34');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (30, 30, '2023-08-28 08:10:47');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (31, 31, '2023-08-28 07:39:07');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (32, 32, '2023-08-28 08:46:59');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (33, 33, '2023-08-28 09:01:54');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (34, 34, '2023-08-29 17:27:24');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (35, 35, '2023-08-29 19:18:07');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (36, 36, '2023-08-30 04:34:13');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (37, 37, '2023-08-30 12:22:28');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt, assign_end_dt) VALUES (38, 38, '2023-08-30 13:09:16', '2023-09-19 08:06:01');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (39, 39, '2023-08-31 01:20:40');
INSERT INTO lnk_computer_user (user_id, computer_id, assign_start_dt) VALUES (40, 40, '2023-08-31 04:19:22');
