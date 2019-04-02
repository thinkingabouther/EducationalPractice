string = ""
for i in range(0, 101):
    string += '"'+str(3**(i*(i-1)//2)) + '", '
print(string)