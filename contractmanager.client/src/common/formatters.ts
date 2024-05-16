export function ToCurrency(value: number): string {
  return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
}

export function ToShortDate(value: string): string {
    if(!value) return "";
    
  return new Date(value).toLocaleDateString();
}