interface IBrowserStorage {
  Length(storage: string): number;
  Key(storage: string, index: number): any;
  GetItem(storage: string, key: string): any;
  SetItem(storage: string, key: string, keyValue: string): void;
  RemoveItem(storage: string, key: string): void;
  Clear(storage: string): void;
};

export class BrowserStorage implements IBrowserStorage {
  public Length(storage: string): number {
    return window[storage].length;
  };

  public Key(storage: string, index: number): any {
    return window[storage].key(index);
  };

  public GetItem(storage: string, key: string): any {
    const item = window[storage].getItem(key);

    if (item) {
      return JSON.parse(item);
    }

    return null;
  };

  public SetItem(storage: string, key: string, keyValue: any): void {
    window[storage].setItem(key, JSON.stringify(keyValue));
  };

  public RemoveItem(storage: string, key: string): void {
    window[storage].removeItem(key);
  };

  Clear(storage: string): void {
    window[storage].clear();
  };
};
