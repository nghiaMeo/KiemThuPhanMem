import time
import os
from threading import Thread
from selenium import webdriver


username = "nghia181032"
access_key = "paZj20vOymXhct08d15S228xiqSpBuaRyNsGe72KBtIC4ptteb"

def get_browser(caps):
	return webdriver.Remote(
            command_executor="https://{}:{}@hub.lambdatest.com/wd/hub".format(username, access_key),
            desired_capabilities=caps
        )

# You can configure your test capabilities here 

browsers = [{
    "build": 'PyunitTest sample build', # Change your build name here
    "name": 'Py-unittest1', # Change your test name here
    "platformName": "Android",
    "deviceName": "Galaxy A8"
},
   {
    "build": 'PyunitTest sample build', # Change your build name here
    "name": 'Py-unittest2', # Change your test name here
    "platformName": "iOS",
    "deviceName": "iPad Pro (10.5-inch)"
}]
browsers_waiting = []

# Running the test cases
def get_browser_and_wait(browser_data):
        
    try:
        driver = get_browser(browser_data)
        # Url
        driver.get("http://thongtindaotao.sgu.edu.vn/")
        val = 40 # in seconds
        driver.implicitly_wait(val)
        check_field_tk = driver.find_element_by_name("ctl00$ContentPlaceHolder1$ctl00$ucDangNhap$txtTaiKhoa")
        check_field_tk.send_keys("3119511042")
        
        # Click on check box
        check_filed_pass = driver.find_element_by_name("ctl00$ContentPlaceHolder1$ctl00$ucDangNhap$txtMatKhau")
        check_filed_pass.send_keys("nghia0339941057")
        # Enter item in login
        check_box = driver.find_element_by_id("ctl00_ContentPlaceHolder1_ctl00_ucDangNhap_btnDangNhap")
        check_box.click()
        # Click on add button
        #check_text = driver.find_element_by_id("ctl00_ContentPlaceHolder1_ctl00_ucDangNhap_lblError")
        #check_text.send_keys("Sai thông tin đăng nhập")
        check_text = driver.find_element_by_id("ctl00_Header1_Logout1_lblNguoiDung") 
        #check_text.send_keys("Chào bạn Nguyễn Hữu Nghĩa (3119411042)")
        
        driver.execute_script("lambda-status=passed")
    except:
        driver.execute_script("lambda-status=failed")
    driver.quit()


thread_list = []
for i, browser in enumerate(browsers):
	t = Thread(target=get_browser_and_wait, args=[browser])
	thread_list.append(t)
	t.start()

for t in thread_list:
	t.join()
