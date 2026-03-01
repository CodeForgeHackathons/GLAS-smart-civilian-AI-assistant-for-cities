const isDev = import.meta.env.DEV
const isLoggingEnabled = import.meta.env.VITE_ENABLE_LOGGING !== 'false'

function shouldLog() {
  return isDev && isLoggingEnabled
}

export const logger = {
  log(...args: unknown[]) {
    if (!shouldLog()) return
    console.log('[GLAS]', ...args)
  },
  warn(...args: unknown[]) {
    if (!shouldLog()) return
    console.warn('[GLAS]', ...args)
  },
  error(...args: unknown[]) {
    if (!shouldLog()) return
    console.error('[GLAS]', ...args)
  },
}

