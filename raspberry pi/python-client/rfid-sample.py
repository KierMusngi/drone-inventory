import serial

#EPC C1 G2（ISO18000-6C）COMMAND
INVENTORY=0x01
READ_DATA=0x02
WRITE_DATA=0x03
KILL_TAG=0x05
LOCK=0x06
BLOCK_ERASE=0x07
READ_PROTECT=0x08
READ_PROTECT_WITHOUT_EPC=0x09
RESET_READ_PROTECT=0x0A
CHECK_READ_PROTECT=0x0B
EAS_ALARM=0x0C
CHECK_EAS_ALARM=0x0D
BLOCK_LOCK=0x0E
INVENTORY_SINGLE=0x0F
BLOCK_WRITE=0x10

#READER DEFINED COMMAND
GET_READER_INFORMATION=0x21
SET_REGION=0x22
SET_ADDRESS=0x24
SET_SCANTIME=0x25
SET_BAUDRATE=0x28
SET_POWER=0x2F
ACOUSTO_OPTIC_CONTROL=0x33
SET_WIEGAND=0x34
SET_WORK_MODE=0x35
GET_WORK_MODE=0x36
SET_EAS_ACCURACY=0x37
SYRIS_RESPONSE_OFFSET=0x38
TRIGGER_OFFSET=0x3B

# Connects to serial port with default 9600 baudrate
ser = serial.Serial('COM6')
print(ser.name)
print(ser.is_open)

def getResponse(self, parse=False):
        """retrive data from connection"""
        data = None

        deadline = time.time() + self.timeout
        while data is None:
            if time.time() >= deadline:
                raise Exception()
            
            if self.communication == "socket":
                self.connection.settimeout(deadline - time.time())
                data = self.connection.recv(self.buffer_size)
            elif self.communication == 'serial':
                data = self.connection.readline()

        if parse:
            data = hexlify(data)
            
            return {
                'len': int(data[0:2], 16),
                'addr': data[2:4].decode('utf-8'),
                'reCmd': data[4:6].decode('utf-8'),
                'data': data[6:-4],
                'lsb': data[-4:-2],
                'msb': data[-2:],
            }
        
        return data

def getInfo(self):
    sendCommand(GET_READER_INFORMATION)
    resp = self.getResponse(True)
    data = resp.get('data')
    print('resp', data)