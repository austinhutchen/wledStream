#!/bin/bash
exec esptool.py write_flash 0x0 'esp32_bootloader_v4 (1).bin'
