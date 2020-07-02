--Update Room Amout In Hotel
CREATE TRIGGER UpdateRoomAmoutAfterInsertInBooking ON BookingDetails AFTER INSERT AS
BEGIN
	UPDATE RoomOfHotel
	SET RoomAmount = RoomAmount - (
		SELECT NumberOfNights
		FROM inserted i
		WHERE i.HotelID = RoomOfHotel.HotelID  AND i.RoomID = RoomOfHotel.RoomID
	)
	--Join với bảng vừa insert để update theo điều kiện
	FROM RoomOfHotel
	JOIN inserted ON RoomOfHotel.HotelID = inserted.HotelID AND RoomOfHotel.RoomID = inserted.RoomID
END