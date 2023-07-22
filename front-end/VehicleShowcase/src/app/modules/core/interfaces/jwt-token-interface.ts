export interface JwtToken {
    acessToken: string;
    expirationTime: Date;
    issuedAt: Date;
}