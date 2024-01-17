import {Injectable} from "@angular/core";

@Injectable({
    providedIn: 'root'
})
export class StorageService {
    storage: Storage;

    constructor() {
      this.storage = window.localStorage;
    }
    getInline(key: string) : string{
      return this.storage.getItem(key) ?? "";
    }

    get<TModel>(key : string) : TModel | null {
      let item = this.storage.getItem(key);
      if (item) {
        console.log(`item: ${item}`);
        return JSON.parse(item);
      }
      return null;
    }
    set(key: string, value: string) {
      this.storage.setItem(key, JSON.stringify(value));
    }
}
