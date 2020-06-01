import { Manga } from "./manga";

export class MangaPages {
    id: number;
    manga: Manga;
    pages: Array<{ id: number, pageImageBase64: string }>
}