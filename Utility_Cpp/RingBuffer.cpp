#include "../_CppTemplate.cpp"

/// @brief 双方向キューくん
/// @tparam 格納するデータ型
template <class T>
class DoubleEndedQueue {
  private:
    // クラス内で使うノード構造体
    class Node {
      public:
        T     data;
        Node *next;
        Node *prev;

        Node(T d) {
            this->data = d;
            this->next = NULL;
            this->prev = NULL;
        }
    };

    // 配列っぽいやつ(前後に入れられるように)
    Node *head;
    Node *tail;

  public:
    // 要素数
    ll size;

    DoubleEndedQueue() {
        this->size = 0;
        this->head = NULL;
        this->tail = NULL;
    }

    // 先頭要素取り出し
    T front() {
        if (size == 0) return NULL;
        return this->head->data;
    }

    // 最後の要素取り出し
    T back() {
        if (size == 0) return NULL;
        return this->back->data;
    }

    // 先頭に要素追加
    void push_front(T data) {
        Node *node = new Node(data);
        // 要素がなければheadとtailをその要素に
        if (this->size == 0) {
            this->head = node;
            this->tail = node;
            this->size = 1;
        }
        // データがあれば先頭だけ変更
        else {
            node->next       = this->head;
            this->head->prev = node;
            this->head       = node;
            this->size += 1;
        }
    } // end of method

    // 最後に要素追加
    void push_back(T data) {
        Node *node = new Node(data);

        // 要素がなければheadとtailをその要素に
        if (this->size == 0) {
            this->head = node;
            this->tail = node;
            this->size = 1;
        }
        // データがあれば最後だけ変更
        else {
            node->prev       = this->tail;
            this->tail->next = node;
            this->tail       = node;
            this->size += 1;
        }
    } // end of method

    // 先頭の要素を取り出し
    T pop_front() {
        // 要素数が0ならぬるぽ
        if (this->size == 0) {
            cout << "Error : ぬるぽ" << endl;
            exit(-1);
        }

        T ret = this->head->data;
        // 要素数が1ならheadとtailをNULLにする
        if (this->size == 1) {
            free(this->head);
            this->head = NULL;
            this->tail = NULL;
        }
        // データあれば先頭だけ削除
        else {
            this->head = this->head->next;
            free(this->head->prev);
        }

        this->size -= 1;
        return ret;
    } // end of method

    // 最後の要素を取出し
    T pop_back() {
        // 要素数が0ならぬるぽ
        if (this->size == 0) {
            cout << "Error : ぬるぽ" << endl;
            exit(-1);
        }

        T ret = this->tail->data;
        // 要素数が1ならheadとtailをNULLにする
        if (this->size == 1) {
            free(this->head);
            this->head = NULL;
            this->tail = NULL;
        }
        // データがあれば最後だけ削除
        else {
            this->tail = this->tail->prev;
            free(this->tail->next);
        }

        this->size -= 1;
        return ret;
    } // end of method

    void show() {
        if (this->size == 0) {
            cout << "No Elements" << endl;
            return;
        }

        Node *tmp = this->head;
        cout << "head:" << head << " tail" << tail << endl;
        cout << "size:" << this->size << endl
             << "value:";
        while (true) {
            cout << tmp->data << " ";
            if (tmp->next == NULL) break;
            tmp = tmp->next;
        }

        cout << endl;
    } // end of method
};