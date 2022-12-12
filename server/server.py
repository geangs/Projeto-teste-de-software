import socket
import threading
import sqlite3

port = 1111
SERVER = 'localhost'
address = (SERVER, port)
format = 'ascii'
server = socket.socket(socket.AF_INET, socket.SOCK_STREAM, 0)
server.bind(address)

clients = []

def get_coins(player,con,c):
    c.execute('SELECT * FROM TEST WHERE player = "%s"' % player)
    return c.fetchone()[2]

def add_coins(player,coins,con,c):
    c.execute("UPDATE TEST SET COINS = '%s' WHERE PLAYER = '%s' " % (get_coins(player,con,c)+coins,player))
    con.commit()

def get_rank(player,con,c):
    c.execute('SELECT * FROM TEST WHERE player = "%s"' % player)
    return c.fetchone()[3]

def add_rank(player,rank,con,c):
    c.execute("UPDATE TEST SET RANK = '%s' WHERE PLAYER = '%s' " % (get_rank(player,con,c)+rank,player))
    con.commit()

def get_cards(player,con,c):
    c.execute('SELECT * FROM TEST WHERE player = "%s"' % player)
    return c.fetchone()[1]

def buy_card(player,card,con,c):
    if get_coins(player,con,c) >= 100:
        add_coins(player,-100,con,c)
        c.execute("UPDATE TEST SET CARDS = '%s' WHERE PLAYER = '%s' " % (get_cards(player,con,c)+' '+card, player))
        con.commit()

def sell_card(player,card,con,c):
    if card in get_cards(player,con,c):
        add_coins(player,100,con,c)
        c.execute("UPDATE TEST SET CARDS = '%s' WHERE PLAYER = '%s' " % (get_cards(player,con,c).replace(card,''), player))
        con.commit()
        return True
    return False


def card_unlocked(player,card,con,c):
    return card in get_cards(player,con,c)

class Client:
    def __init__(self, conn):
        self.conn = conn
        self.connected = True

def handle_client(client):

    con = sqlite3.connect('test.db')
    c = con.cursor()

    while client.connected:
        conn = client.conn
        msg = conn.recv(500).decode(format)

        s = msg[:-1].split(' ')
        com = s[0]

        if com == 'get_coins':
            conn.send(str(get_coins(s[1],con,c)).encode(format))
        elif com == 'add_coins':
            add_coins(s[1],int(s[2]),con,c)
            conn.send('success'.encode(format))
        elif com == 'get_rank':
            conn.send(str(get_rank(s[1],con,c)).encode(format))
        elif com == 'add_rank':
            add_rank(s[1],int(s[2]),con,c)
            conn.send('success'.encode(format))
        elif com == 'get_cards':
            conn.send(str(get_cards(s[1],con,c)).encode(format))
        elif com == 'buy_card':
            buy_card(s[1],s[2],con,c)
            conn.send('success'.encode(format))
        elif com == 'sell_card':
            if sell_card(s[1], s[2], con, c):
                conn.send('success'.encode(format))
            else:
                conn.send('failure'.encode(format))

        if msg[0] == '!':
            client.connected = False

        print(msg)
        #conn.send((msg + 'received').encode(format))

    conn.close()


def start():
    server.listen()
    while True:
        conn, addr = server.accept()
        client = Client(conn)
        clients.append(client)
        thread = threading.Thread(target=handle_client, args=[client])
        thread.start()

start()
