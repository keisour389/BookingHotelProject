--Insert value to Partner
INSERT INTO Partners
VALUES ('TTC', N'Thành Thành Công', '2020-08-24', '0901234567',
'ttc@gmail.com', N'Tp. Hồ Chí Minh', 0, N'Đang hợp tác', null)
,('RHVN', N'Red House', '2020-05-11', '0901234567',
'rhvn@gmail.com', N'Hà Nội', 0, N'Đang hợp tác', null)
,('TRCT', N'Terracotta', '2020-7-1', '0901234567',
'trct@gmail.com', N'Lâm Đồng', 0, N'Đang hợp tác', null)

--Insert value to Hotel
INSERT INTO Hotel
VALUES ('TTCDL', N'Khách sạn TTC Đà Lạt', 3, '2020-08-24', '0901234567',
'ttc@gmail.com', N'4 Đường Nguyễn Thị Minh Khai',  N'Phường 1',
N'Phường 1', N'Đà Lạt, tỉnh Lâm Đồng', N'Việt Nam',
'https://owa.bestprice.vn/images/hotels/large/ttc-hotel-premium-da-lat-5db1708c714b2-848x477.jpg',
 null, N'Đang hoạt động', 10, N'Trực tuyến', 'TTC', null)
 ,
 ('TTCPQ', N'Khách sạn TTC Phú Quốc', 4, '2020-08-24', '0901234567',
'ttc@gmail.com', N'Dương đông',  N'Phường 4',
N'Phường 4', N'Phú Quốc, tỉnh Kiên Giang', N'Việt Nam',
'https://www.hotelbooking.com.vn/hotelvietnam-images/product/img2/OIAN5UHWG_77b5d67db7a0493f97bd3c603624d239.jpg',
 null, N'Đang hoạt động', 10, N'Trực tuyến', 'TTC', null)
 ,
 ('TTCPT', N'Khách sạn TTC Phan Thiết', 3, '2020-08-24', '0901234567',
'ttc@gmail.com', N'Bãi sau',  N'Phường 9',
N'Liên khu 1', N'Phan Thiết, tỉnh Phan Thiết', N'Việt Nam',
'https://du-lich.chudu24.com/f/m/1707/28/_N4_3143-HDR.jpg?w=550&c=1',
 null, N'Đang hoạt động', 10, N'Trực tuyến', 'TTC', null)
 ,
 ('TRCTDL', N'Resort Terracotta Đà Lạt', 4, '2020-08-24', '0901234567',
'ttc@gmail.com', N'Phân khu chức năng 7.9, KDL hồ Tuyền Lâm',  N'Phường 3',
N'Phường 3', N'Đà Lạt, Tỉnh Lâm Đồng', N'Việt Nam',
'https://salt.tikicdn.com/ts/tmp/fd/af/b9/6896b3db930357dbf2606ea47260e32a.jpg',
 null, N'Đang hoạt động', 10, N'Trực tuyến', 'TRCT', null)
 ,
 ('RHDL', N'Khách sạn Red House Đà Lạt', 2, '2020-08-24', '0901234567',
'ttc@gmail.com', N'12 Nam Kì Khởi Nghĩa',  N'Phường 10',
N'Phường 10', N'Đà Lạt, Tỉnh Lâm Đồng', N'Việt Nam',
'https://pix10.agoda.net/hotelImages/517/517526/517526_13082220230014513457.jpg?s=1024x768',
 null, N'Đang hoạt động', 10, N'Trực tuyến', 'RHVN', null)

 --Insert value to Room of hotel
 INSERT INTO RoomOfHotel
 VALUES('TTCDLTR', 'Twin', 10, 1, 2, N'Wifi miễn phí,Ăn sáng miễn phí',
 N'Không áp dụng hủy phòng', '12:00', '14:00', 1000000, 0,
 null, '2020-08-24', null, 'TTCDL')
 ,
('TTCDLSR', 'Standard', 10, 2, 4, N'Wifi miễn phí,Ăn sáng miễn phí',
 N'Không áp dụng hủy phòng', '12:00', '14:00', 1200000, 0.1,
 null, '2020-08-24', null, 'TTCDL')
 ,
 ('TTCPQTR', 'Twin', 10, 1, 2, N'Wifi miễn phí,Ăn sáng miễn phí',
 N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 900000, 0,
 null, '2020-08-24', null, 'TTCPQ')
 ,
('TTCPQSR', 'Standard', 10, 2, 4, N'Wifi miễn phí,Ăn sáng miễn phí',
N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 1400000, 0.2,
 null, '2020-08-24', null, 'TTCPQ')
 ,
 ('TTCPTTR', 'Twin', 10, 1, 2, N'Wifi miễn phí,Ăn sáng miễn phí',
 N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 800000, 0,
 null, '2020-08-24', null, 'TTCPT')
 ,
('TTCPTSR', 'Standard', 10, 2, 4, N'Wifi miễn phí,Ăn sáng miễn phí',
N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 1100000, 0.1,
 null, '2020-08-24', null, 'TTCPT')
 ,
('TRCTDLTR', 'Twin', 10, 1, 2, N'Wifi miễn phí,Ăn sáng miễn phí',
N'Không áp dụng hủy phòng', '12:00', '14:00', 1400000, 0.1,
null, '2020-08-24', null, 'TRCTDL')
 ,
('TRCTDLSR', 'Standard', 10, 2, 4, N'Wifi miễn phí,Ăn sáng miễn phí',
N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 1600000, 0.1,
null, '2020-08-24', null, 'TRCTDL')
,
('RHDLTR', 'Twin', 10, 1, 2, N'Wifi miễn phí',
N'Không áp dụng hủy phòng', '12:00', '14:00', 700000, 0,
null, '2020-08-24', null, 'RHDL')
,
('RHDLSR', 'Standard', 10, 2, 4, N'Wifi miễn phí,Ăn sáng miễn phí',
N'Không áp dụng hủy phòng,Không được thuê chòi miễn phí', '12:00', '14:00', 1000000, 0,
null, '2020-08-24', null, 'RHDL')

 --Insert value to Customer
 Insert INTO CusAccount
 VALUES('0902725706', '25f9e794323b453885f5181f1b624d0b', N'Khách hàng thường', '2020-08-18', N'Bình thường', null)

 Insert INTO Customers
 VALUES('0902725706', N'Tiêu Tuấn', N'Kiệt', '1999-08-03', '1751010068kiet@ou.edu.vn', N'Nam', 1, null)

