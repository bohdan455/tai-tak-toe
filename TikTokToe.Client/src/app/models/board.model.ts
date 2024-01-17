export interface Board {
  winner: string | null;
  cells: {
    value: number;
    row: number;
    column: number;
  }[];
}
