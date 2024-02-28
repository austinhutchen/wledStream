esptool.exe -p COM10 erase_flash esptool.exe -p COM10 write_flash Ox0
C3
_bootloader. bin
esptool.exe -p COM10 write_flash 0x8000
С3
_partitions.bin
esptool.exe -p COM10 write_flash 0x010000
6_may_lolin_c3
_mini_T2.bin